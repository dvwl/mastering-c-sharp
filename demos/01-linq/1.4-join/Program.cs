using Model;

namespace Join;

public class Program
{
	static void Main(string[] args)
	{
		List<Student> students =
		[
			new Student { FirstName = "John", LastName = "Doe", ID = 1, Year = GradeLevel.FirstYear, Scores = [90, 80, 70], DepartmentID = 1 },
			new Student { FirstName = "Jane", LastName = "Smith", ID = 2, Year = GradeLevel.SecondYear, Scores = [85, 90, 75], DepartmentID = 2 },
			new Student { FirstName = "Jake", LastName = "Doe", ID = 3, Year = GradeLevel.ThirdYear, Scores = [88, 70, 92], DepartmentID = 3 },
			new Student { FirstName = "Tony", LastName = "Field", ID = 4, Year = GradeLevel.ThirdYear, Scores = [90, 80, 88], DepartmentID = 1 },
			new Student { FirstName = "Sharon", LastName = "Green", ID = 5, Year = GradeLevel.ThirdYear, Scores = [96, 95, 70], DepartmentID = 1 },
			new Student { FirstName = "Daren", LastName = "Smile", ID = 6, Year = GradeLevel.FourthYear, Scores = [90, 99, 89], DepartmentID = 2 },
		];

		List<Teacher> teachers =
		[
			new Teacher { FirstName = "Alice", LastName = "Johnson", ID = 1, City = "New York" },
			new Teacher { FirstName = "Bob", LastName = "Doe", ID = 2, City = "Los Angeles" },
			new Teacher { FirstName = "Charlie", LastName = "Brown", ID = 3, City = "Chicago" },
			new Teacher { FirstName = "Daren", LastName = "Smile", ID = 4, City = "Los Angeles" }
		];

		List<Department> departments =
		[
			new Department { Name = "Math", ID = 1, TeacherID = 1  },
			new Department { Name = "Physics", ID = 2, TeacherID = 3 },
			new Department { Name = "Chemistry", ID = 3, TeacherID = 2 }
		];

		// Join Operators
		var query = from student in students
					join department in departments on student.DepartmentID equals department.ID
					select new { Name = $"{student.FirstName} {student.LastName}", DepartmentName = department.Name };

		foreach (var item in query)
		{
			Console.WriteLine($"{item.Name} - {item.DepartmentName}");
		}

		IEnumerable<IEnumerable<Student>> studentGroups = from department in departments
														  join student in students on department.ID equals student.DepartmentID into studentGroup
														  select studentGroup;

		foreach (IEnumerable<Student> studentGroup in studentGroups)
		{
			Console.WriteLine("Group");
			foreach (Student student in studentGroup)
			{
				Console.WriteLine($"  - {student.FirstName} {student.LastName}");
			}
		}

		// Join the two data sources based on a composite key consisting of first and last name,
		// to determine which employees are also students.
		IEnumerable<string> queryST =
			from teacher in teachers
			join student in students on new
			{
				teacher.FirstName,
				teacher.LastName
			} equals new
			{
				student.FirstName,
				student.LastName
			}
			select teacher.FirstName + " " + teacher.LastName;

		string result = "\nThe following people are both teachers and students:\r\n";
		foreach (string name in queryST)
		{
			result += $"{name}\r\n";
		}
		Console.WriteLine(result);

		// The first join matches Department.ID and Student.DepartmentID from the list of students and
		// departments, based on a common ID. The second join matches teachers who lead departments
		// with the students studying in that department.
		var querySDT = from student in students
					   join department in departments on student.DepartmentID equals department.ID
					   join teacher in teachers on department.TeacherID equals teacher.ID
					   select new
					   {
						   StudentName = $"{student.FirstName} {student.LastName}",
						   DepartmentName = department.Name,
						   TeacherName = $"{teacher.FirstName} {teacher.LastName}"
					   };

		foreach (var obj in querySDT)
		{
			Console.WriteLine($"""The student "{obj.StudentName}" studies in the department run by "{obj.TeacherName}".""");
		}

		// GroupJoin
		// In this example, we will group students by their departments using GroupJoin.
		var departmentStudents = departments.GroupJoin(
			students,
			department => department.ID,    // Key from the departments list (outer)
			student => student.DepartmentID, // Key from the students list (inner)
			(department, studentGroup) => new
			{
				DepartmentName = department.Name,
				Students = studentGroup
			});

		Console.WriteLine("Departments and their students:");
		foreach (var department in departmentStudents)
		{
			Console.WriteLine($"Department: {department.DepartmentName}");
			if (!department.Students.Any())
			{
				Console.WriteLine("  No students");
			}
			else
			{
				foreach (var student in department.Students)
				{
					Console.WriteLine($"  - {student.FirstName} {student.LastName}");
				}
			}
		}
	}
}
