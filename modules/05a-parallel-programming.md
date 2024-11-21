---
lab:
    title: 'Exploring Parallel Programming in C#'
---
# Module 05a: Exploring Parallel Programming in C#
In this module, you will learn how to utilize parallel programming to improve performance in C#. You'll explore the benefits of parallel execution and identify common challenges such as race conditions, as well as techniques to mitigate these issues.

## Exercise: Handling Shared Resources in Parallel Programming
Imagine you are building a futuristic city simulation where various systems (like transportation, energy, and infrastructure) need to update shared counters concurrently. Understanding the challenges of shared resource access in a parallelized context will help you design robust solutions.

**Instructions:**

1. **Understand the Problem:** When multiple threads or tasks modify a shared resource, a race condition can occur, leading to unpredictable results.

2. **Explore the Issue:**
   - Write a program that demonstrates a race condition by incrementing a shared counter in parallel.

3. **Mitigate the Issue:**
   - Use thread-safe mechanisms such as `Interlocked` to safely update the shared resource.

### Example: Race Condition and Mitigation

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Shared counter variable
        int sharedCounter = 0;

        // Simulating parallel tasks with race condition
        Parallel.For(0, 1000, i =>
        {
            // Uncomment the next line to observe the race condition
            // sharedCounter++;

            // Thread-safe increment using Interlocked
            Interlocked.Increment(ref sharedCounter);
        });

        Console.WriteLine($"Final Counter Value: {sharedCounter}");
        // The result with Interlocked will be 1000. Without it, it might be less due to race conditions.
    }
}
```

**Expected Outcome:**
Learners will understand the concept of race conditions and why they occur.
They will successfully mitigate race conditions using thread-safe constructs like Interlocked.

**Next Steps:**
Extend the program to explore other thread-safety mechanisms such as lock or Monitor.
Implement additional scenarios where shared resources need to be protected, like maintaining a collection of log entries or managing a producer-consumer queue.

Happy experimenting.
