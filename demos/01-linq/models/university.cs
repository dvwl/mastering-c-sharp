namespace Model;

public enum GradeLevel
{
	FirstYear = 1,
	SecondYear,
	ThirdYear,
	FourthYear
};

public class Student
{
	public string FirstName { get; init; }
	public string LastName { get; init; }
	public int ID { get; init; }
	public GradeLevel Year { get; init; }
	public List<int> Scores { get; init; }
	public int DepartmentID { get; init; }
}

public class Teacher
{
	public required string FirstName { get; init; }
	public required string LastName { get; init; }
	public required int ID { get; init; }
	public required string City { get; init; }
}

public class Department
{
	public required string Name { get; init; }
	public int ID { get; init; }
	public required int TeacherID { get; init; }
}