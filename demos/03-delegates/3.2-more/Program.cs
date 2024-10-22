namespace More;

class Program
{
	// Func method to calculate the distance from the origin (0,0,0)
	static double CalculateDistance(double x, double y, double z) => Math.Sqrt(x * x + y * y + z * z);

	// Action method to launch a spacecraft
	static void Launch(string message) => Console.WriteLine("Launch Operation: " + message);

	// Predicate method to check if fuel is critical (below a threshold)
	static bool IsFuelCritical(double fuelLevel) => fuelLevel < 20.0; // Critical if fuel is below 20

	static void Main(string[] args)
	{
		// Action Example: Performing an Operation
		Action<string> launchAction = Launch;
		launchAction("Rocket Falcon 9 is ready for launch!");

		// Func Example: Calculating Distance
		Func<double, double, double, double> calculateDistance = CalculateDistance;
		double distance = calculateDistance(1.0, 2.0, 3.0); // Coordinates (1, 2, 3)
		Console.WriteLine($"Distance from origin: {distance}");

		// Predicate Example: Checking Fuel Status
		List<double> fuelLevels = [ 100.0, 50.5, 0.0, 75.3 ];
		Predicate<double> isFuelCritical = IsFuelCritical;

		foreach (var fuel in fuelLevels)
		{
			if (isFuelCritical(fuel))
			{
				Console.WriteLine($"Fuel level {fuel} is critical!");
			}
			else
			{
				Console.WriteLine($"Fuel level {fuel} is sufficient.");
			}
		}
	}
}
