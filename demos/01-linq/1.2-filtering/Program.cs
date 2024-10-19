namespace Filtering;

class Program
{
	static void Main(string[] args)
	{
		// Filtering Operators
		string[] words = ["humpty", "dumpty", "set", "on", "a", "wall"];

		// Query Syntax
		IEnumerable<string> query = from word in words
									where word.Length == 3
									select word;

		// Method Syntax
		//IEnumerable<string> query = words.Where(word => word.Length == 3);

		foreach (string str in query)
			Console.WriteLine(str);
	}
}
