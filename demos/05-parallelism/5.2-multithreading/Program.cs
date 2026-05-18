namespace multithreading;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Hello multithreading: tasks, threads, and threadpool!");

		// Creating and running a task
		Task task = Task.Run(() =>
		{
			Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Task is running on thread: {Thread.CurrentThread.ManagedThreadId}");
		});

		// Waiting for the task to complete
		task.Wait();
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Task completed.");

		// Creating and starting a thread
		Thread thread = new Thread(() =>
		{
			Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Thread is running on thread: {Thread.CurrentThread.ManagedThreadId}");
		});

		// Start the thread
		thread.Start();
		// Wait for the thread to finish
		thread.Join();
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Thread completed.");

		// Queuing work to the ThreadPool
		ThreadPool.QueueUserWorkItem(state =>
		{
			Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Task is running in ThreadPool on thread: {Thread.CurrentThread.ManagedThreadId}");
		});

		// Queueing work items
		for (int i = 0; i < 5; i++)
		{
            _ = ThreadPool.QueueUserWorkItem(DoWork, i);
		}

		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Main thread does some work.");
		Thread.Sleep(1000); // Simulate some work

		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Main thread ends.");
	}

	static void DoWork(object state)
	{
		int threadNumber = (int)state;
		Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Thread {threadNumber} is executing on thread: {Thread.CurrentThread.ManagedThreadId}");
		Thread.Sleep(500); // Simulate work
	}
}
