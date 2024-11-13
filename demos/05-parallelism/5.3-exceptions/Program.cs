namespace exceptions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World of Error Handling & Exceptions!");
        RunParallelTasks();
    }

    public static void RunParallelTasks()
    {
        Task[] tasks = new Task[3];

        for (int i = 0; i < tasks.Length; i++)
        {
            int taskId = i; // Capture the loop variable
            tasks[i] = Task.Run(() =>
            {
                if (taskId == 1)
                    throw new InvalidOperationException($"Task {taskId} failed."); // Simulate an exception
                Console.WriteLine($"Task {taskId} completed successfully.");
            });
        }

        try
        {
            Task.WaitAll(tasks);
        }
        catch (AggregateException ex)
        {
            foreach (var innerEx in ex.InnerExceptions)
            {
                Console.WriteLine($"Exception: {innerEx.Message}");
            }
        }
    }
}
