// Scenarios:
// Let's assume we are planning a space mission, and different methods are responsible for different tasks, such as launching, landing, and communication. We'll use a delegate to execute these methods. (Basic Delegates)
// During a space mission, multiple systems need to be initialized at once, like navigation and communication. (Multicast Delegates)
// During the mission, we need a quick, temporary check on fuel levels that we don’t need elsewhere in the program. (Anonymous Delegates)
// We have different spacecraft models. Some checks are common across all (static), while others are specific to each spacecraft (instance). (Delegates with Static Methods)

namespace Delegates;

// Define a delegate that matches the signature of methods to be called
public delegate void MissionControl(string message);
public delegate void SystemControl();
public delegate void QuickCheck();
public delegate void SpacecraftCheck();

class Spacecraft
{
	public static void GeneralCheck() => Console.WriteLine("General spacecraft check complete.");
	public void SpecificCheck() => Console.WriteLine("Specific spacecraft model check complete.");
}

class Program
{
	// Basic Delegates
	static void Launch(string message) => Console.WriteLine("Launch sequence initiated: " + message);
	static void Land(string message) => Console.WriteLine("Landing sequence initiated: " + message);

	// Multicast Delegates
	static void InitializeNavigation() => Console.WriteLine("Navigation system initialized.");
	static void InitializeCommunication() => Console.WriteLine("Communication system initialized.");

	static void Main(string[] args)
	{
		// Create delegate instances
		MissionControl missionDelegate;
		SystemControl systemDelegate;

		// Assign the 'Launch' method to the delegate
		missionDelegate = Launch;
		missionDelegate("All systems go!");

		// Reassign to the 'Land' method
		missionDelegate = Land;
		missionDelegate("Entering atmosphere.");

		// Adding both methods to the delegate chain
		systemDelegate = InitializeNavigation;
		systemDelegate += InitializeCommunication;

		// Invokes both methods in sequence
		systemDelegate();

		// Using an anonymous method for a quick fuel check
		QuickCheck fuelCheck = delegate
		{
			Console.WriteLine("Performing quick fuel check: Fuel levels stable.");
		};

		// Invoke the anonymous method
		fuelCheck();

		Spacecraft spacecraft = new();

		// Delegate pointing to a static method
		SpacecraftCheck checkDelegate = Spacecraft.GeneralCheck;
		checkDelegate();

		// Delegate pointing to an instance method
		checkDelegate = spacecraft.SpecificCheck;
		checkDelegate();
	}
}
