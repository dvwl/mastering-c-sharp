namespace Partitioning;

class Program
{
	static void Main(string[] args)
	{
		// Partition Operators
		Console.WriteLine("Take: ");
		foreach (int number in Enumerable.Range(0, 8).Take(3))
			Console.WriteLine(number);

		Console.WriteLine("\nSkip: ");
		foreach (int number in Enumerable.Range(0, 8).Skip(3))
			Console.WriteLine(number);

		Console.WriteLine("\nTakeWhile: ");
		foreach (int number in Enumerable.Range(0, 8).TakeWhile(n => n < 5))
			Console.WriteLine(number);

		Console.WriteLine("\nSkipWhile: ");
		foreach (int number in Enumerable.Range(0, 8).SkipWhile(n => n < 5))
			Console.WriteLine(number);

		Console.WriteLine("\nChunk: ");
		int chunkNumber = 1;
		foreach (int[] chunk in Enumerable.Range(0, 8).Chunk(3))
		{
			Console.WriteLine($"Chunk {chunkNumber++}:");
			foreach (int item in chunk)
				Console.WriteLine($"    {item}");

			Console.WriteLine();
		}
	}
}
