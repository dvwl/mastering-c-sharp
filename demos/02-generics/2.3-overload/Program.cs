namespace Overload;

class Program
{
    // Generic method with one type parameter
    // int, char, string, etc. can be passed as T
    public static void Display<T>(T value) => 
		Console.WriteLine($"Displaying value: {value}"); 

    // Overloaded generic method that transforms the input value before displaying it
    public static void Display<T>(T value, Func<T, T> transform)
    {
        T manipulatedValue = transform(value);
        Console.WriteLine($"Displaying transformed value: {manipulatedValue}");
    }

    // Named transform helper for integers
    public static int CubeValue(int value) => value * value * value;

    // Named transform helper for strings
    public static string ToLowerString(string value) => value.ToLower();

    // Overloaded generic method with two type parameters
    public static void Display<T, U>(T firstValue, U secondValue) => 
        Console.WriteLine($"Displaying values: {firstValue} and {secondValue}");
    
    // Overloaded method with different parameter count but same type
    public static void Display<T>(T firstValue, T secondValue) => 
        Console.WriteLine($"Displaying two of the same type: {firstValue} and {secondValue}");

    static void Main(string[] args)
    {
        // Call the generic method with one parameter
        Display(42);
        Display("Hello");

        // Call the overloaded generic method that transforms the input value
        Display(7, value => value * 2);
        Display("Hello", text => text.ToUpper());

        // Call the overloaded generic method with a named transform function
        Display(7, CubeValue);
        Display("World!", ToLowerString);

        // Call the overloaded generic method with two different type parameters
        Display(10, "Generic Method Overloading");

        // Call the overloaded method with two parameters of the same type
        Display<double>(3.14, 2.71);
    }
}