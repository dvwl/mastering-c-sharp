namespace Sample;

// Base class for all university entities
public abstract class UniversityMember
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// Specific entity classes
public class Student : UniversityMember
{
    public string Major { get; set; }
}

public class Teacher : UniversityMember
{
    public string Subject { get; set; }
}

public class Department
{
    public string DepartmentName { get; set; }
}

// Generic repository class
public class Repository<T> where T : class
{
    private List<T> _items = [];

    // Add an item to the repository
    public void Add(T item)
    {
        _items.Add(item);
        Console.WriteLine($"{typeof(T).Name} added.");
    }

    // Get all items from the repository
    public List<T> GetAll() => _items;

    // Find an item by its index (simplified for demo)
    public T GetByIndex(int index) => _items[index];
}

class Program
{
    static void Main(string[] args)
    {
        // Create repositories for different university entities
        Repository<Student> studentRepository = new();
        Repository<Teacher> teacherRepository = new();
        Repository<Department> departmentRepository = new();

        // Add students
        studentRepository.Add(new Student { Id = 1, Name = "Alice", Major = "Computer Science" });
        studentRepository.Add(new Student { Id = 2, Name = "Bob", Major = "Mathematics" });

        // Add teachers
        teacherRepository.Add(new Teacher { Id = 1, Name = "Dr. Smith", Subject = "Physics" });
        teacherRepository.Add(new Teacher { Id = 2, Name = "Dr. Johnson", Subject = "Philosophy" });

        // Add departments
        departmentRepository.Add(new Department { DepartmentName = "Engineering" });
        departmentRepository.Add(new Department { DepartmentName = "Humanities" });

        // Retrieve and display data from repositories
        var students = studentRepository.GetAll();
        Console.WriteLine("Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Name} - Major: {student.Major}");
        }

        var teachers = teacherRepository.GetAll();
        Console.WriteLine("\nTeachers:");
        foreach (var teacher in teachers)
        {
            Console.WriteLine($"{teacher.Name} - Subject: {teacher.Subject}");
        }

        var departments = departmentRepository.GetAll();
        Console.WriteLine("\nDepartments:");
        foreach (var department in departments)
        {
            Console.WriteLine($"Department: {department.DepartmentName}");
        }
    }
}
