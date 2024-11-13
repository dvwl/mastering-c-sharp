namespace basic;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello parallel programming!");

		// Simple example of parallel for loop
		Parallel.For(0, 10, i =>
		{
			Console.WriteLine($"Processing item {i} on thread {Thread.CurrentThread.ManagedThreadId}");
		});

		// Demonstrating a scenario with Parallel.ForEach
		List<string> files = ["file1.txt", "file2.txt", "file3.txt"];
		Parallel.ForEach(files, file =>
		{
			Console.WriteLine($"Processing {file} on thread {Thread.CurrentThread.ManagedThreadId}");
			Thread.Sleep(1000); // Simulate file processing
		});

		// Example of a race condition
		int sharedCounter = 0;
		Parallel.For(0, 1000, i =>
		{
			#region Spoiler
			// Safely increment sharedCounter
    		// Interlocked.Increment(ref sharedCounter);
			#endregion

			// Potentially unsafe update due to race condition
			sharedCounter++;
		});
		Console.WriteLine($"Final Counter Value: {sharedCounter}");
		// The result might be less than 1000 due to concurrent access issues
	}
}
