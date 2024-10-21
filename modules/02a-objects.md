---
lab:
    title: 'Observing the Weakness of Object'
---
# Module 02a: Observing the Weakness of Object
In this exercise, you will explore the limitations of using `Object` types, specifically in terms of type safety and performance. You will experiment with the `ArrayList` class and compare it with a generic `List<int>` to understand the consequences of working with non-generic collections.

## Exercise 1: Type Safety with Object
In this exercise, you will create an `ArrayList` that contains both integers and strings. You will then attempt to retrieve and cast these elements back to their original types.

**Instructions:**
1. Create an ArrayList and add both integers and strings to it.
2. Attempt to retrieve and cast the elements back to their original types.
3. Observe and note the exceptions or issues that arise (e.g., `InvalidCastException`).

Code Example:
```csharp
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        ArrayList items = new ArrayList();
        items.Add(10);      // Adding an integer
        items.Add("Hello"); // Adding a string

        // Try to retrieve and cast
        try
        {
            int number = (int)items[1]; // This will throw an exception
            Console.WriteLine(number);
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
```

**Expected Outcome:**
- The code will throw an `InvalidCastException` when attempting to cast a string to an integer.
- This demonstrates the potential runtime issues and lack of type safety when using `ArrayList`.

## Exercise 2: Performance Comparison – `ArrayList` vs `List<int>`
Next, you will compare the performance of an `ArrayList` versus a generic `List<int>`. This will highlight the performance overhead caused by boxing/unboxing when using `ArrayList`.

**Instructions:**
1. Write code to add one million integers to both an `ArrayList` and a `List<int>`.
2. Measure the time taken to perform the operation for both collections.
3. Observe the performance differences caused by boxing/unboxing in the `ArrayList`.

Code Example for Performance Test:
```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Timing ArrayList performance
        ArrayList list = [];
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < 1000000; i++) list.Add(i);
        stopwatch.Stop();
        Console.WriteLine($"ArrayList Time: {stopwatch.ElapsedMilliseconds} ms");

        // Timing List<int> performance
        List<int> genericList = [];
        stopwatch.Restart();
        for (int i = 0; i < 1000000; i++) genericList.Add(i);
        stopwatch.Stop();
        Console.WriteLine($"List<int> Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
```

**Expected Outcome:**
- The `ArrayList` will be slower due to the overhead of boxing/unboxing.
- The `List<int>` will perform faster, showcasing the benefits of using generics for type safety and performance optimization.

## Key Takeaways
- ArrayList can lead to runtime errors due to the lack of type safety.
- `List<int>` avoids these issues and offers better performance by eliminating boxing/unboxing.

Enjoy every moment of your exploration adventure!
