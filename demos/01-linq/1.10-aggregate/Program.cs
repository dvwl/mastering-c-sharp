using Model;

namespace Aggregate;

class Program
{
	static void Main(string[] args)
	{
		List<Student> students =
		[
			new Student { FirstName = "John", LastName = "Doe", ID = 1, Year = GradeLevel.FirstYear, Scores = new List<int>{90, 80, 70}, DepartmentID = 1 },
			new Student { FirstName = "Jane", LastName = "Smith", ID = 2, Year = GradeLevel.SecondYear, Scores = new List<int>{85, 90, 75}, DepartmentID = 2 },
			new Student { FirstName = "Jake", LastName = "Doe", ID = 3, Year = GradeLevel.ThirdYear, Scores = new List<int>{88, 70, 92}, DepartmentID = 3 },
			new Student { FirstName = "Tony", LastName = "Field", ID = 4, Year = GradeLevel.ThirdYear, Scores = new List<int>{90, 80, 88}, DepartmentID = 1 },
			new Student { FirstName = "Sharon", LastName = "Green", ID = 5, Year = GradeLevel.ThirdYear, Scores = new List<int>{96, 95, 70}, DepartmentID = 1 },
			new Student { FirstName = "Daren", LastName = "Smile", ID = 6, Year = GradeLevel.FourthYear, Scores = new List<int>{90, 99, 89}, DepartmentID = 2 },
		];

		// Aggregate Operators
		// Count: Total number of students
		int studentCount = students.Count();
		Console.WriteLine($"Total number of students: {studentCount}");

		// Sum: Total of all scores
		int totalScores = students.Sum(s => s.Scores.Sum());
		Console.WriteLine($"Total of all scores: {totalScores}");

		// Average: Average score per student
		double averageScore = students.Average(s => s.Scores.Average());
		Console.WriteLine($"Average score per student: {averageScore:F2}");

		// Min: Minimum score among all students
		int minScore = students.Min(s => s.Scores.Min());
		Console.WriteLine($"Minimum score: {minScore}");

		// Max: Maximum score among all students
		int maxScore = students.Max(s => s.Scores.Max());
		Console.WriteLine($"Maximum score: {maxScore}");

		// Aggregate: Concatenate all student names into a single string
		string allNames = students.Select(s => s.FirstName + " " + s.LastName)
								  .Aggregate((current, next) => current + ", " + next);
		Console.WriteLine($"All student names: {allNames}");
	}
}
