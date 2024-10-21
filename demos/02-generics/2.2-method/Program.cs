namespace Method;

// Generic Method
class Program
{
	// Define a generic method that swaps two values
	public static void Swap<T>(ref T a, ref T b)
	{
        (b, a) = (a, b);	// uses Tuple to swap values
    }

    static void Main(string[] args)
	{
		// Example 1: Swapping integers
		int num1 = 5, num2 = 10;
		Console.WriteLine($"Before swap: num1 = {num1}, num2 = {num2}");
		Swap(ref num1, ref num2);
		Console.WriteLine($"After swap: num1 = {num1}, num2 = {num2}");

		// Example 2: Swapping strings
		string str1 = "Hello", str2 = "World";
		Console.WriteLine($"\nBefore swap: str1 = \"{str1}\", str2 = \"{str2}\"");
		Swap(ref str1, ref str2);
		Console.WriteLine($"After swap: str1 = \"{str1}\", str2 = \"{str2}\"");

		// Example 3: Swapping custom objects
		DateTime date1 = DateTime.Now, date2 = DateTime.UtcNow;
		Console.WriteLine($"\nBefore swap: date1 = {date1}, date2 = {date2}");
		Swap(ref date1, ref date2);
		Console.WriteLine($"After swap: date1 = {date1}, date2 = {date2}");
	}
}
