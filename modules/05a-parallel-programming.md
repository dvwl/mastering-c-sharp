---
lab:
    title: 'Exploring Functional Programming in a Futuristic City'
---
# Module 04: Exploring Functional Programming in a Futuristic City
In this module, you will learn how to utilize lambda expressions to perform operations on collections effectively. You'll explore how to enhance your programming capabilities by employing functional programming techniques in a futuristic context.

## Exercise: Managing Transportation Methods in a Futuristic City
Imagine a futuristic city with various modes of transportation, including hovercars, drones, and hyperloop trains. Each mode of transportation has different attributes such as speed, capacity, and fuel efficiency. In this exercise, you will create a collection of these transportation methods and use lambda expressions to filter, sort, and manipulate the data.

**Instructions:**
1. **Define a Transportation Class:** Create a class called `Transportation` with properties such as `Name`, `Speed`, `Capacity`, and `FuelEfficiency`. Make the class immutable by using readonly properties and a constructor to set the values.
2. **Create a List of Transportation Methods:** Instantiate a list with several transportation objects.
3. **Use Lambda Expressions:**
   - Filter the list to find transportation methods with a speed greater than 200 mph.
   - Sort the filtered list by fuel efficiency in descending order.
   - Create a string representation of each method in the final list.

Example:
```csharp
class Transportation
{
    public string Name { get; set; }
    public double Speed { get; set; }           // Speed in mph
    public int Capacity { get; set; }           // Number of passengers
    public double FuelEfficiency { get; set; }  // MPG

    public override string ToString()
    {
        return $"{Name}: {Speed} mph, Capacity: {Capacity}, Fuel Efficiency: {FuelEfficiency} MPG";
    }
}

...

// Create a list of transportation methods
List<Transportation> transports = new List<Transportation>
{
    new Transportation("Hovercar A", 220, 4, 30),
    new Transportation("Drone B", 150, 2, 50),
    new Transportation("Hyperloop C", 300, 50, 100),
    new Transportation("Hovercar D", 180, 4, 25),
    new Transportation("Drone E", 200, 1, 70)
};
```

**Expected Outcome:**
- Learners will successfully create a collection of transportation methods and apply lambda expressions to filter and sort the data.
- They will understand how to leverage functional programming concepts to manipulate collections in a concise and readable manner.

**Next Steps:** 
Experiment further by adding more attributes to the `Transportation` class, creating additional filtering and sorting criteria, or incorporating user input to enhance interactivity.
