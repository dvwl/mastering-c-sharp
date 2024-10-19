using Model;

namespace Set;

class Program
{
	static void Main(string[] args)
	{
		// Set Operators
		string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"];
		string[] words1 = ["the", "quick", "brown", "fox"];
		string[] words2 = ["jumped", "over", "the", "lazy", "dog"];

		// Distinct, Unique words
		IEnumerable<string> queryD = from word in words.Distinct() select word;
		// DisticntBy, The first words of different lengths
		IEnumerable<string> queryDby = from word in words.DistinctBy(p => p.Length) select word;
		// Except, Words in set 1 that are not in set 2
		IEnumerable<string> queryE = from word in words1.Except(words2) select word;
		// ExceptBy, The first word in the original set (3, 5, 5, 3, 6, 4, 3, 4, 3) with different length from set 2 (6, 4, 3, 4, 3)
		IEnumerable<string> queryEby = from word in words1.ExceptBy(words2.Select(w => w.Length), p => p.Length) select word;
		// Intersect, Same words in both set 1 and set 2
		IEnumerable<string> queryI = from word in words1.Intersect(words2) select word;
		// IntersectBy, words from original set which intersect with words from set 2 of different lengths
		IEnumerable<string> queryIby = from word in words.IntersectBy(words2.Select(w => w.Length), p => p.Length) select word;
		// Union, Union of set 1 and set 2
		IEnumerable<string> queryU = from word in words1.Union(words2) select word;

		Console.WriteLine("Distinct: ");
		foreach (var str in queryD)
			Console.WriteLine(str);

		Console.WriteLine("\nDistinctBy: ");
		foreach (var str in queryDby)
			Console.WriteLine(str);

		Console.WriteLine("\nExcept: ");
		foreach (var str in queryE)
			Console.WriteLine(str);

		Console.WriteLine("\nExceptBy: ");
		foreach (var str in queryEby)
			Console.WriteLine(str);

		Console.WriteLine("\nIntersect: ");
		foreach (var str in queryI)
			Console.WriteLine(str);

		Console.WriteLine("\nIntersectBy: ");
		foreach (var str in queryIby)
			Console.WriteLine(str);

		Console.WriteLine("\nUnion: ");
		foreach (var str in queryU)
			Console.WriteLine(str);

		// University Theme:
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

		var distinctStudents = students.Select(s => s.LastName).Distinct();
		Console.WriteLine("\nDistinct Student Last Names:");
		foreach (var lastName in distinctStudents)
		{
			Console.WriteLine(lastName);
		}

		var distinctStudentsByDepartment = students.DistinctBy(s => s.DepartmentID);
		Console.WriteLine("\nDistinct Students by Department:");
		foreach (var student in distinctStudentsByDepartment)
		{
			Console.WriteLine($"{student.FirstName} {student.LastName} - Department ID: {student.DepartmentID}");
		}

		// A list of students to exclude (e.g., based on last names)
		var excludedStudents = new List<string> { "Doe", "Smith" };
		var remainingStudents = students.Where(s => !excludedStudents.Contains(s.LastName));

		Console.WriteLine("\nStudents except those with last names 'Doe' and 'Smith':");
		foreach (var student in remainingStudents)
		{
			Console.WriteLine($"{student.FirstName} {student.LastName}");
		}

		var departmentIDsToExclude = new List<int> { 1, 3 };
		var studentsInOtherDepartments = students.ExceptBy(departmentIDsToExclude, s => s.DepartmentID);

		Console.WriteLine("\nStudents in departments except Math and Chemistry:");
		foreach (var student in studentsInOtherDepartments)
		{
			Console.WriteLine($"{student.FirstName} {student.LastName} - Department ID: {student.DepartmentID}");
		}

		// A list of last names shared between teachers and students
		var teacherLastNames = teachers.Select(t => t.LastName);
		var studentTeacherCommonLastNames = students.Select(s => s.LastName).Intersect(teacherLastNames);

		Console.WriteLine("\nCommon last names between students and teachers:");
		foreach (var lastName in studentTeacherCommonLastNames)
		{
			Console.WriteLine(lastName);
		}

		// Find students whose DepartmentID intersects with a list of departments by ID
		var departmentIDs = departments.Select(d => d.ID);
		var studentsInIntersectingDepartments = students.IntersectBy(departmentIDs, s => s.DepartmentID);

		Console.WriteLine("\nStudents in intersecting departments:");
		foreach (var student in studentsInIntersectingDepartments)
		{
			Console.WriteLine($"{student.FirstName} {student.LastName} - Department ID: {student.DepartmentID}");
		}

		// A list of additional students
		var newStudents = new List<Student>
		{
			new() { FirstName = "Lily", LastName = "White", ID = 7, Year = GradeLevel.FirstYear, Scores = new List<int> { 85, 80, 90 }, DepartmentID = 2 }
		};

		var allStudents = students.Union(newStudents);
		Console.WriteLine("\nAll students after adding new students (Union):");
		foreach (var student in allStudents)
		{
			Console.WriteLine($"{student.FirstName} {student.LastName}");
		}

		// Union: Combine the first names of students and teachers, removing duplicates
		var unionNames = students.Select(s => s.FirstName)
								 .Union(teachers.Select(t => t.FirstName));

		Console.WriteLine("Union of Student and Teacher First Names:");
		foreach (var name in unionNames)
		{
			Console.WriteLine(name);
		}

		// Intersect: Find common last names between students and teachers
		var commonLastNames = students.Select(s => s.LastName)
									  .Intersect(teachers.Select(t => t.LastName));

		Console.WriteLine("\nCommon Last Names between Students and Teachers:");
		foreach (var lastName in commonLastNames)
		{
			Console.WriteLine(lastName);
		}

		// Except: Find students' last names that are not in the teachers' last names
		var studentUniqueLastNames = students.Select(s => s.LastName)
											 .Except(teachers.Select(t => t.LastName));

		Console.WriteLine("\nLast Names of Students not in Teachers:");
		foreach (var lastName in studentUniqueLastNames)
		{
			Console.WriteLine(lastName);
		}

		var unionByLastName = students.Select(s => new { s.FirstName, s.LastName })
									  .UnionBy(teachers.Select(t => new { t.FirstName, t.LastName }), p => p.LastName);

		Console.WriteLine("\nSUnionBy Last Names (Students + Teachers):");
		foreach (var person in unionByLastName)
		{
			Console.WriteLine($"{person.FirstName} {person.LastName}");
		}

		// IntersectBy: Find common last names between students and teachers
		var intersectByLastName = students.IntersectBy(teachers.Select(t => t.LastName), s => s.LastName);

		Console.WriteLine("\nIntersectBy Last Names (Common between Students and Teachers):");
		foreach (var student in intersectByLastName)
		{
			Console.WriteLine($"{student.FirstName} {student.LastName}");
		}

		// ExceptBy: Find students whose last names are not in the teachers' last names
		var exceptByLastName = students.ExceptBy(teachers.Select(t => t.LastName), s => s.LastName);

		Console.WriteLine("\nExceptBy Last Names (Students not in Teachers):");
		foreach (var student in exceptByLastName)
		{
			Console.WriteLine($"{student.FirstName} {student.LastName}");
		}
	}
}
