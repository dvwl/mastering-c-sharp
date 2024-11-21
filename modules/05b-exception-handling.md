---
lab:
    title: 'Handling Exceptions in Sequential and Parallel Programming'
---
# Module 05b: Handling Exceptions in Sequential and Parallel Programming
In this module, you will learn how to raise and handle exceptions effectively in C#. You will explore exception handling in both sequential and parallel programs, gaining insights into best practices for robust application development.

## Exercise 1: Raising and Handling Exceptions in a Sequential Program
In a futuristic city's energy management system, exceptions may occur due to invalid configurations or resource constraints. This exercise demonstrates how to handle such errors in a sequential program.

**Instructions:**

1. **Simulate an Exception:**
   - Create a method that throws an exception when an invalid input is provided.
2. **Handle the Exception:**
   - Use a `try-catch` block to manage the error gracefully and log the details.

### Example Code:

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SimulateEnergyLoad(-1);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void SimulateEnergyLoad(int load)
    {
        if (load < 0)
        {
            throw new ArgumentException("Load value cannot be negative.");
        }

        Console.WriteLine($"Energy load set to {load} units.");
    }
}
```

**Expected Outcome:**
- Learners will understand how to raise exceptions using the throw keyword and handle them with `try-catch`.

## Exercise 2: Handling Exceptions in a Parallel Program
Parallel tasks in the futuristic city might fail independently. This exercise explores how to aggregate and handle exceptions that occur during parallel execution.

**Instructions:**
1. **Simulate Multiple Tasks**:
- Use Parallel.For or Task.Run to create tasks, some of which throw exceptions.
2. **Aggregate Exceptions**:
- Handle exceptions using AggregateException to capture all errors.

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Parallel.For(0, 5, i =>
            {
                if (i % 2 == 0)
                {
                    throw new InvalidOperationException($"Task {i} failed.");
                }
                Console.WriteLine($"Task {i} completed successfully.");
            });
        }
        catch (AggregateException ae)
        {
            foreach (var ex in ae.InnerExceptions)
            {
                Console.WriteLine($"Caught exception: {ex.Message}");
            }
        }
    }
}
```

**Expected Outcome:**
- Understand how exceptions propagate in parallel programs.
- Learn to handle multiple exceptions using AggregateException.

**Next Steps:** 
- Experiment with different exception types in sequential and parallel programs.
- Implement custom exception classes to provide more context in error messages.
