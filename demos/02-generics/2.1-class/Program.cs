namespace Class;

// Generic Class
// Define a generic class with a type parameter T
public class Box<T>(T content)
{
	private T _content = content;

	// Method to get the content of the box
	public T GetContent() => _content;

	// Method to set or update the content of the box
	public void SetContent(T content) => _content = content;

	// Override the ToString method to display the content
	public override string ToString() => $"Box contains: {_content}";
}

class Program
{
	static void Main(string[] args)
	{
		// Create a Box instance for an integer
		Box<int> intBox = new(123);
		Console.WriteLine(intBox);  // Output: Box contains: 123

		// Create a Box instance for a string
		Box<string> stringBox = new("Hello, World!");
		Console.WriteLine(stringBox);  // Output: Box contains: Hello, World!

		// Create a Box instance for a custom type
		Box<DateTime> dateBox = new(DateTime.Now);
		Console.WriteLine(dateBox);  // Output: Box contains: <current date and time>

		// Update the content of the stringBox
		stringBox.SetContent("Goodbye, World!");
		Console.WriteLine(stringBox);  // Output: Box contains: Goodbye, World!
	}
}
