using Model;

namespace Generation;

class Pet
{
	public string Name { get; set; }
	public int Age { get; set; }
}

class Program
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

		// Generation Operators
		// DefaultIfEmpty
		var departmentWithNoStudents = departments
			.Where(d => d.ID == 4) // Assuming there's no department with ID 4
			.SelectMany(d => students.Where(s => s.DepartmentID == d.ID))
			.DefaultIfEmpty(new Student { FirstName = "No", LastName = "Students" });

		Console.WriteLine("Students in department with no students (using DefaultIfEmpty):");
		foreach (var student in departmentWithNoStudents)
		{
			Console.WriteLine($"{student.FirstName} {student.LastName}");
		}

		// Range
		var studentIDs = Enumerable.Range(7, 3); // Generates IDs 7, 8, 9
		var newStudents = studentIDs.Select(id => new Student
		{
			FirstName = "New",
			LastName = $"Student{id}",
			ID = id,
			Year = GradeLevel.FirstYear,
			Scores = [80, 85, 90],
			DepartmentID = 2
		});

		Console.WriteLine("Generated students using Enumerable.Range:");
		foreach (var student in newStudents)
		{
			Console.WriteLine($"{student.FirstName} {student.LastName} - ID: {student.ID}");
		}

		// Repeat
		Teacher placeholderTeacher = new() 
		{
			FirstName = "Placeholder",
			LastName = "Teacher",
			ID = 0,
			City = "Unknown"
		};

		var repeatedTeachers = Enumerable.Repeat(placeholderTeacher, 3);

		Console.WriteLine("Repeated placeholder teacher objects using Enumerable.Repeat:");
		foreach (var teacher in repeatedTeachers)
		{
			Console.WriteLine($"{teacher.FirstName} {teacher.LastName} - City: {teacher.City}");
		}
	}
}
