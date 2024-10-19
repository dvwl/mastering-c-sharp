namespace Element;

class Program
{
	static void Main(string[] args)
	{
		// Element Operators
		// Example data: Array of strings
		string[] fruits = ["Apple", "Banana", "Cherry", "Date", "Elderberry"];

		// First: Get the first element
		string firstFruit = fruits.First();
		Console.WriteLine($"First fruit: {firstFruit}");

		// Last: Get the last element
		string lastFruit = fruits.Last();
		Console.WriteLine($"Last fruit: {lastFruit}");

		// ElementAt: Get the element at a specific index (e.g., index 2)
		string thirdFruit = fruits.ElementAt(2);
		Console.WriteLine($"Third fruit (index 2): {thirdFruit}");

		// Single: Get the only element in a sequence that has exactly one element
		// Here we use Single() on a subset that contains exactly one element
		string singleFruit = fruits.Where(f => f == "Cherry").Single();
		Console.WriteLine($"Single fruit: {singleFruit}");
	}
}
