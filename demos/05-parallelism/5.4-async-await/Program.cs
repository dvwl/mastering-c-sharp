namespace async_await;

class Program
{
	static async Task Main(string[] args)
	{
		// Execute the methods
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Starting async tasks...");

		// Simulate a long calculation task
		await CalculateAsync();

		// Run tasks concurrently
		await RunTasksConcurrentlyAsync();

		// Run tasks sequentially
		await RunTasksSequentiallyAsync();

		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Async tasks completed.");
	}

	// Simulates a long-running calculation task
	public static int LongCalculation()
	{
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Starting LongCalculation...");
		Thread.Sleep(3000); // Simulate a delay
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] LongCalculation completed.");
		return 42; // Return a result after the calculation
	}

	// An async method that performs a long-running calculation asynchronously
	public static async Task<int> CalculateAsync()
	{
		int result = await Task.Run(() => LongCalculation());
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Calculation result: {result}");
		return result;
	}

	// An async method that performs Task1 and Task2 asynchronously
	public static async Task PerformTaskAsync()
	{
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Performing Task1 asynchronously...");
		await Task.Run(() => Task1());

		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Performing Task2 asynchronously...");
		await Task.Run(() => Task2());
	}

	// Simulate tasks that will be run sequentially
	public static async Task RunTasksSequentiallyAsync()
	{
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Running tasks sequentially...");
		await Task1();
		await Task2();
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Sequential tasks completed.");
	}

	// Simulate tasks that will be run concurrently
	public static async Task RunTasksConcurrentlyAsync()
	{
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Running tasks concurrently...");
		var task1 = Task1();
		var task2 = Task2();
		await Task.WhenAll(task1, task2);
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Concurrent tasks completed.");
	}

	// Simulate Task1
	public static async Task Task1()
	{
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Task1 starting...");
		await Task.Delay(2000); // Simulates async work with a 2-second delay
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Task1 completed.");
	}

	// Simulate Task2
	public static async Task Task2()
	{
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Task2 starting...");
		await Task.Delay(3000); // Simulates async work with a 3-second delay
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Task2 completed.");
	}
}
