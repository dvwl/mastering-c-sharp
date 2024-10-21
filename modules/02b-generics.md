---
lab:
    title: 'Exploring Generics: Storing and Processing Cosmic Data'
---
# Module 02b: Exploring Generics: Storing and Processing Cosmic Data
In this exercise module, we dive into the world of generics to enhance code flexibility and reusability. You'll be working on a space-themed exercise where you'll create a generic class, method, and overload to process, store, and manipulate data related to celestial objects.

## Exercise 3: Creating a Generic Class for Cosmic Data
Your first task is to create a generic class that can store and manipulate data about various celestial objects, like stars, planets, or asteroids.

**Instructions:**
1. Create a generic class `CosmicData<T>` that can store data of any type.
2. Include methods for adding, retrieving, and displaying the data.
3. Test the class with different data types (e.g., string for star names, int for the number of planets, etc.).

Class Example:
```csharp
class CosmicData<T>
{
    private List<T> data = [];

    // Method to add data

    // Method to retrieve data

    // Method to display all data

}
```

**Expected Outcome:**
- You should be able to store and retrieve different types of cosmic data, such as stars and planets, reinforcing the flexibility that generics provide.

## Exercise 4: Implementing a Generic Method for Cosmic Calculations
Now, extend your work by creating a generic method that performs a calculation on the cosmic data. For example, calculating the average mass of a group of planets.

**Instructions:**
1. Write a generic method `CalculateAverage<T>` that works for any numerical type (e.g., `int`, `double`).
2. Test the method with different types of numerical data, such as the mass of planets.

```csharp
int[] planetMasses = { 100, 200, 300 };
double averageMass = CosmicCalculator.CalculateAverage(planetMasses);
Console.WriteLine($"Average Planet Mass: {averageMass}");
```

**Expected Outcome:**
- You should be able to calculate the average of various numerical data types, demonstrating the power of generic methods.

## Exercise 5: Overloading Generic Methods for Specific Use Cases
Finally, you'll explore how to overload a generic method to handle specific cases, such as when you're dealing with a particular type of data (e.g., star names).

**Instructions:**
1. Overload the `AddData` method in the `CosmicData<T>` class to handle a special case for `string` types.
2. Modify the overloaded method to add a prefix like "Star: " when storing star names.

```csharp
CosmicData<string> starNames = new CosmicData<string>();
starNames.AddData("Sirius");
starNames.AddData("Betelgeuse");
starNames.DisplayData();
```

**Expected Outcome:**
- The overloaded method will add a prefix to star names while still allowing for generic usage in other cases.
- This reinforces how generics and method overloading can work together for flexibility.

## Key Takeaways
- Using generics in classes and methods improves code reusability and type safety.
- Overloading methods allows you to handle special cases without compromising the generic nature of your code.

May your coding journey be filled with fun and discovery!
