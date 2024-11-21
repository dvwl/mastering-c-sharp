---
lab:
    title: 'Exploring Asynchronous Programming in C#'
---
# Module 05c: Exploring Asynchronous Programming in C#
In this module, you will learn how to implement asynchronous programming using `async` and `await`. You'll explore how futuristic city systems can perform long-running tasks efficiently without blocking resources.

## Exercise: Managing Long-Running Tasks in a Futuristic City
Imagine a futuristic city's resource management system that needs to perform computationally intensive tasks such as energy load calculations and infrastructure monitoring. Asynchronous programming can ensure that these tasks run efficiently without delaying other operations.

**Instructions:**

1. **Simulate a Long-Running Task:**
   - Create a method that simulates a time-consuming calculation, such as determining optimal energy distribution.
2. **Perform the Task Asynchronously:**
   - Use `async` and `await` to execute the task without blocking the main thread.
3. **Run Tasks Sequentially and Concurrently:**
   - Compare the execution of tasks sequentially and concurrently.

### Example Code:

#### Simulating a Long-Running Calculation
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

public class FuturisticCity
{
    public static int LongCalculation()
    {
        Console.WriteLine("Starting LongCalculation...");
        Thread.Sleep(3000); // Simulate a delay
        Console.WriteLine("LongCalculation completed.");
        return 42; // Return a result after the calculation
    }

    public static async Task<int> CalculateAsync()
    {
        int result = await Task.Run(() => LongCalculation());
        Console.WriteLine($"Calculation result: {result}");
        return result;
    }
}
```

#### Performing Tasks Sequentially and Concurrently
```csharp
public static async Task Task1()
{
    Console.WriteLine("Task1: Monitoring energy grid...");
    await Task.Delay(2000); // Simulate task delay
    Console.WriteLine("Task1 completed.");
}

public static async Task Task2()
{
    Console.WriteLine("Task2: Analyzing infrastructure...");
    await Task.Delay(3000); // Simulate task delay
    Console.WriteLine("Task2 completed.");
}

public static async Task RunTasksSequentiallyAsync()
{
    Console.WriteLine("Running tasks sequentially...");
    await Task1();
    await Task2();
    Console.WriteLine("Sequential tasks completed.");
}

public static async Task RunTasksConcurrentlyAsync()
{
    Console.WriteLine("Running tasks concurrently...");
    var task1 = Task1();
    var task2 = Task2();
    await Task.WhenAll(task1, task2);
    Console.WriteLine("Concurrent tasks completed.");
}
```

**Expected Outcome:**
- Observe the difference in execution time between sequential and concurrent task execution.
- Understand how async and await work in real-world scenarios.

**Next Steps:**
- Modify the tasks to include error handling using try-catch for exceptions in asynchronous methods.
- Experiment with returning data from tasks and aggregating results.

Happy awaiting!
