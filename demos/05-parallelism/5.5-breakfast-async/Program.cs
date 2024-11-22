// Example from:
// https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
using System.Threading.Tasks;

namespace breakfast_async;

// These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
internal class Bacon { }
internal class Coffee { }
internal class Egg { }
internal class Juice { }
internal class Toast { }

class Program
{
	static void Main(string[] args)
	{
		Coffee cup = PourCoffee();
		Console.WriteLine("coffee is ready");

		Egg eggs = FryEggs(2);
		Console.WriteLine("eggs are ready");

		Bacon bacon = FryBacon(3);
		Console.WriteLine("bacon is ready");

		Toast toast = ToastBread(2);
		ApplyButter(toast);
		ApplyJam(toast);
		Console.WriteLine("toast is ready");

		Juice oj = PourOJ();
		Console.WriteLine("oj is ready");
		Console.WriteLine("Breakfast is ready!");
	}

	#region Spoiler
	// static async Task Main(string[] args)
	// {
	// 	Coffee cup = PourCoffee();
	// 	Console.WriteLine("coffee is ready");

	// 	Task<Egg> eggsTask = FryEggsAsync(2);
	// 	Task<Bacon> baconTask = FryBaconAsync(3);
	// 	Task<Toast> toastTask = MakeToastWithButterAndJamAsync(2);

	// 	List<Task> breakfastTasks = [eggsTask, baconTask, toastTask];
	// 	while (breakfastTasks.Count > 0)
	// 	{
	// 		Task finishedTask = await Task.WhenAny(breakfastTasks);
	// 		if (finishedTask == eggsTask)
	// 		{
	// 			Console.WriteLine("eggs are ready");
	// 		}
	// 		else if (finishedTask == baconTask)
	// 		{
	// 			Console.WriteLine("bacon is ready");
	// 		}
	// 		else if (finishedTask == toastTask)
	// 		{
	// 			Console.WriteLine("toast is ready");
	// 		}

	// 		#region Optimize if and else if
	// 		// string message = finishedTask switch
	// 		// {
	// 		// 	var task when task == eggsTask => "eggs are ready",
	// 		// 	var task when task == baconTask => "bacon is ready",
	// 		// 	var task when task == toastTask => "toast is ready",
	// 		// 	_ => throw new InvalidOperationException("Unknown task finished")
	// 		// };
	// 		// Console.WriteLine(message);
	// 		#endregion

	// 		await finishedTask;
	// 		breakfastTasks.Remove(finishedTask);
	// 	}

	// 	Juice oj = PourOJ();
	// 	Console.WriteLine("oj is ready");

	// 	if (cup != null && 
	// 		breakfastTasks.Count == 0 && 
	// 		oj != null)
	// 	{
	// 		Console.WriteLine("Breakfast is ready!");
	// 	}
	// }
	#endregion

	private static Juice PourOJ()
	{
		Console.WriteLine("Pouring orange juice");
		return new Juice();
	}

	private static void ApplyJam(Toast toast) =>
		Console.WriteLine("Putting jam on the toast");

	private static void ApplyButter(Toast toast) =>
		Console.WriteLine("Putting butter on the toast");

	private static Toast ToastBread(int slices)
	{
		for (int slice = 0; slice < slices; slice++)
		{
			Console.WriteLine("Putting a slice of bread in the toaster");
		}
		Console.WriteLine("Start toasting...");
		Task.Delay(3000).Wait();
		Console.WriteLine("Remove toast from toaster");

		return new Toast();
	}

	#region Spoiler
	// private static async Task<Toast> ToastBreadAsync(int slices)
	// {
	// 	for (int slice = 0; slice < slices; slice++)
	// 	{
	// 		Console.WriteLine("Putting a slice of bread in the toaster");
	// 	}
	// 	Console.WriteLine("Start toasting...");
	// 	await Task.Delay(3000);
	// 	Console.WriteLine("Remove toast from toaster");

	// 	return new Toast();
	// }

	// Composition with tasks
	// static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
	// {
	// 	var toast = await ToastBreadAsync(number);
	// 	ApplyButter(toast);
	// 	ApplyJam(toast);

	// 	return toast;
	// }
	#endregion

	private static Bacon FryBacon(int slices)
	{
		Console.WriteLine($"putting {slices} slices of bacon in the pan");
		Console.WriteLine("cooking first side of bacon...");
		Task.Delay(3000).Wait();
		for (int slice = 0; slice < slices; slice++)
		{
			Console.WriteLine("flipping a slice of bacon");
		}
		Console.WriteLine("cooking the second side of bacon...");
		Task.Delay(3000).Wait();
		Console.WriteLine("Put bacon on plate");

		return new Bacon();
	}

	#region Spoiler
	// private static async Task<Bacon> FryBaconAsync(int slices)
	// {
	// 	Console.WriteLine($"putting {slices} slices of bacon in the pan");
	// 	Console.WriteLine("cooking first side of bacon...");
	// 	await Task.Delay(3000);
	// 	for (int slice = 0; slice < slices; slice++)
	// 	{
	// 		Console.WriteLine("flipping a slice of bacon");
	// 	}
	// 	Console.WriteLine("cooking the second side of bacon...");
	// 	await Task.Delay(3000);
	// 	Console.WriteLine("Put bacon on plate");

	// 	return new Bacon();
	// }
	#endregion

	private static Egg FryEggs(int howMany)
	{
		Console.WriteLine("Warming the egg pan...");
		Task.Delay(3000).Wait();
		Console.WriteLine($"cracking {howMany} eggs");
		Console.WriteLine("cooking the eggs ...");
		Task.Delay(3000).Wait();
		Console.WriteLine("Put eggs on plate");

		return new Egg();
	}

	#region Spoiler
	// private static async Task<Egg> FryEggsAsync(int howMany)
	// {
	// 	Console.WriteLine("Warming the egg pan...");
	// 	await Task.Delay(3000);
	// 	Console.WriteLine($"cracking {howMany} eggs");
	// 	Console.WriteLine("cooking the eggs ...");
	// 	await Task.Delay(3000);
	// 	Console.WriteLine("Put eggs on plate");

	// 	return new Egg();
	// }
	#endregion

	private static Coffee PourCoffee()
	{
		Console.WriteLine("Pouring coffee");
		return new Coffee();
	}
}
