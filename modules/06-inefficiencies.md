---
lab:
    title: 'Explore Inefficiencies'
---
# Module 06: Explore Inefficiencies
Welcome to the "Explore Inefficiencies" project! In this exercise, you will work with a simple library management system and apply performance optimization techniques to improve its efficiency.

## Exercise: C# Library Book Management System
This project simulates a library of 10,000 books, each with an ID, Title, Author, and Published Year. The code includes some inefficient methods that perform operations such as:
- Searching for books by a specific author
- Retrieving books published after a certain year
- Counting books within a specific decade

Your objective is to analyze, measure, and optimize these methods for better performance.

**Instructions:**
1. Clone the project repo.
2. Open the project in Visual Studio (or your preferred IDE).
3. Run `Program.cs` to see the baseline performance of the provided methods.
4. Use a `Stopwatch` to measure the time taken by each method.

**Optimization Ideas**
Run this initial version and measure performance, then begin refactoring by:
1. Replacing Loops with LINQ Queries: Use LINQ Where, OrderBy, and Count methods to replace manual loops for filtering, sorting, and counting.
2. Removing Unnecessary List Creation: Use a List projection to avoid repeatedly creating lists in each function.
3. Using Parallel LINQ: For potentially faster data retrieval with large datasets, learners can consider parallelizing operations.

Example Code:
```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishedYear { get; set; }
}

public class Library
{
    public List<Book> Books { get; set; }

    public Library()
    {
        Books = new List<Book>();

        // Adding 10,000 sample books to the library
        for (int i = 1; i <= 10000; i++)
        {
            Books.Add(new Book
            {
                Id = i,
                Title = $"Book Title {i}",
                Author = $"Author {i % 100}",
                PublishedYear = 2000 + (i % 20)
            });
        }
    }

    // Inefficient search method
    public List<Book> GetBooksByAuthor(string author)
    {
        List<Book> result = new List<Book>();

        foreach (var book in Books)
        {
            if (book.Author == author)
            {
                result.Add(book);
            }
        }

        return result;
    }

    // Inefficient filtering and sorting
    public List<Book> GetBooksPublishedAfterYear(int year)
    {
        List<Book> recentBooks = new List<Book>();

        foreach (var book in Books)
        {
            if (book.PublishedYear > year)
            {
                recentBooks.Add(book);
            }
        }

        recentBooks.Sort((x, y) => x.PublishedYear.CompareTo(y.PublishedYear));
        return recentBooks;
    }

    public int CountBooksByDecade(int startYear, int endYear)
    {
        int count = 0;

        foreach (var book in Books)
        {
            if (book.PublishedYear >= startYear && book.PublishedYear <= endYear)
            {
                count++;
            }
        }

        return count;
    }
}

public class Program
{
    public static void Main()
    {
        Library library = new Library();
        Stopwatch stopwatch = new Stopwatch();

        // Measure performance of inefficient methods
        stopwatch.Start();
        var authorBooks = library.GetBooksByAuthor("Author 10");
        stopwatch.Stop();
        Console.WriteLine($"Time taken to retrieve books by author: {stopwatch.ElapsedMilliseconds}ms");

        stopwatch.Restart();
        var recentBooks = library.GetBooksPublishedAfterYear(2010);
        stopwatch.Stop();
        Console.WriteLine($"Time taken to retrieve books published after 2010: {stopwatch.ElapsedMilliseconds}ms");

        stopwatch.Restart();
        int booksInDecade = library.CountBooksByDecade(2010, 2020);
        stopwatch.Stop();
        Console.WriteLine($"Time taken to count books in decade: {stopwatch.ElapsedMilliseconds}ms");
    }
}
```

**Expected Outcome:**
- Successfully create a collection of library books and apply LINQ expressions to filter, sort, and count data efficiently.
- Gain an understanding of how to identify and resolve inefficiencies in code, leveraging LINQ and functional programming concepts to improve readability and performance.

Happy Optimizing!
