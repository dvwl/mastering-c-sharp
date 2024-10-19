using Model;

namespace Projection;

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

		// Projection Operators
		// Select
		var studentFullNames = students.Select(s => $"{s.FirstName} {s.LastName}");

		Console.WriteLine("Student full names using Select:");
		foreach (var name in studentFullNames)
		{
			Console.WriteLine(name);
		}

		// You can also use Select to project more complex structures, like anonymous types:
		var studentInfo = students.Select(s => new
		{
			FullName = $"{s.FirstName} {s.LastName}",
			DepartmentID = s.DepartmentID,
			AverageScore = s.Scores.Average()
		});

		Console.WriteLine("\nProjected student information using Select:");
		foreach (var student in studentInfo)
		{
			Console.WriteLine($"{student.FullName} - DeptID: {student.DepartmentID}, AvgScore: {student.AverageScore}");
		}

		// SelectMany
		var allScores = students.SelectMany(s => s.Scores);

		Console.WriteLine("\nAll scores using SelectMany:");
		foreach (var score in allScores)
		{
			Console.WriteLine(score);
		}

		// You can also use SelectMany with more complex projection:
		var studentScores = students.SelectMany(
			s => s.Scores,
			(student, score) => new { student.FirstName, student.LastName, Score = score }
		);

		Console.WriteLine("\nFlattened student scores using SelectMany:");
		foreach (var studentScore in studentScores)
		{
			Console.WriteLine($"{studentScore.FirstName} {studentScore.LastName} - Score: {studentScore.Score}");
		}

		// Zip
		var studentTeacherPairs = students.Zip(teachers, (student, teacher) =>
			$"{student.FirstName} {student.LastName} - Teacher: {teacher.FirstName} {teacher.LastName}");

		Console.WriteLine("\nStudent and Teacher pairs using Zip:");
		foreach (var pair in studentTeacherPairs)
		{
			Console.WriteLine(pair);
		}
	}
}
