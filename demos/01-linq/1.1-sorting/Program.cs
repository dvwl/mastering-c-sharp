namespace Sorting;

class Program
{
	static void Main(string[] args)
	{
		// Sorting Operators
		int[] num = [-20, 12, 6, 10, 0, -3, 1];

		// A) Create a query that obtain the values in sorted order
		var posNums = from n in num orderby n select n;

		// B) Sort by method
		// var posNums = num.OrderBy(x => x);

		// Execute the query and display the results.
		Console.WriteLine("Values in ascending order: ");
		foreach (int i in posNums)
			Console.Write(i + " \n");

		// A) Descending by query
		var posNumsDesc = from n in num orderby n descending select n;

		// B) Sort descending by method
		// var posNumsDesc = num.OrderByDescending(x => x);

		// Execute the query and display the results.                          
		Console.WriteLine("\nValues in descending order: ");
		foreach (int i in posNumsDesc)
			Console.Write(i + " \n");
	}
}