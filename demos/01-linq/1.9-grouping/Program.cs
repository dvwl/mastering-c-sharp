using Model;

namespace Grouping;

class Program
{
	static void Main(string[] args)
	{
		// Group Operators
		List<int> numbers = new List<int>() { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };

		IEnumerable<IGrouping<int, int>> queryint = from number in numbers
													group number by number % 2;

		foreach (var group in queryint)
		{
			Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");

			foreach (int i in group)
				Console.WriteLine(i);
		}

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

		// Group
		var studentsByYear = students.GroupBy(s => s.Year);

		Console.WriteLine("\nStudents grouped by year:");
		foreach (var group in studentsByYear)
		{
			Console.WriteLine($"Year: {group.Key}");
			foreach (var student in group)
			{
				Console.WriteLine($"  - {student.FirstName} {student.LastName}");
			}
		}

		// GroupBy
		var studentsByYearAndDepartment = students.GroupBy(s => new { s.Year, s.DepartmentID });

		Console.WriteLine("\nStudents grouped by year and department:");
		foreach (var group in studentsByYearAndDepartment)
		{
			Console.WriteLine($"Year: {group.Key.Year}, DepartmentID: {group.Key.DepartmentID}");
			foreach (var student in group)
			{
				Console.WriteLine($"  - {student.FirstName} {student.LastName}");
			}
		}

		// GroupBy Average Score
		var studentsByScoreRange = students.GroupBy(s =>
		{
			double avgScore = s.Scores.Average();
			if (avgScore >= 90) return "High Achievers";
			if (avgScore >= 75) return "Average";
			return "Needs Improvement";
		});

		Console.WriteLine("\nStudents grouped by score range:");
		foreach (var group in studentsByScoreRange)
		{
			Console.WriteLine($"{group.Key}:");
			foreach (var student in group)
			{
				Console.WriteLine($"  - {student.FirstName} {student.LastName} (Avg Score: {student.Scores.Average():F2})");
			}
		}
	}
}
