using answers.extensions;
using answers.models;
using System.Text.Json;

namespace answers;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, Learners! This is just one of many solutions.");

		// Load devices from JSON file
		var devices = LoadDevicesFromJson("data/data.json");

		// Print devices with friendly names
		// Console.WriteLine("\nDevice List:");
		// foreach (var device in devices)
		// {
		// 	Console.WriteLine(device);
		// }

		#region Exercise1
		// Filter devices based on Status
		var filteredOnDevices = devices
			.Where(d => d.Status.Equals("On", StringComparison.OrdinalIgnoreCase))
			.ToList();
		var filteredOffDevices = devices
			.Where(d => d.Status.Equals("Off", StringComparison.OrdinalIgnoreCase))
			.ToList();

		// Example 2 with just Count()
		// Count ON and OFF devices
		var onDevices = devices.Count(d => d.Status.Equals("On", StringComparison.OrdinalIgnoreCase));
		var offDevices = devices.Count(d => d.Status.Equals("Off", StringComparison.OrdinalIgnoreCase));

		// Display results as a bar graph
		Console.WriteLine("Device Status Bar Graph:");
		Console.WriteLine($"ON  : {new string('|', onDevices)} ({onDevices})");
		Console.WriteLine($"OFF : {new string('|', offDevices)} ({offDevices})");
		Console.WriteLine();

		// Example 3 with GroupBy() and Select()
		// Group devices by DeviceType and count ON/OFF statuses
		var groupedDevices = devices
			.GroupBy(d => d.DeviceType)
			.Select(group => new
			{
				DeviceType = group.Key,
				OnCount = group.Count(d => d.Status.Equals("On", StringComparison.OrdinalIgnoreCase)),
				OffCount = group.Count(d => d.Status.Equals("Off", StringComparison.OrdinalIgnoreCase))
			});

		// Display results as a bar graph
		Console.WriteLine("Device Status Bar Graph by Type:");
		foreach (var group in groupedDevices)
		{
			Console.WriteLine($"Type: {group.DeviceType.ToFriendlyString()}");
			Console.WriteLine($"ON  : {new string('|', group.OnCount)} ({group.OnCount})");
			Console.WriteLine($"OFF : {new string('|', group.OffCount)} ({group.OffCount})");
			Console.WriteLine();
		}
		#endregion

		#region Exercise2
		// From Example 1 of Exercise 1
		// Sort the filtered devices by DeviceType and then by DeviceID
		var sortedOnDevices = filteredOnDevices
			.OrderBy(d => d.DeviceType)
			.ThenBy(d => d.DeviceID)
			.ToList();
		var sortedOffDevices = filteredOnDevices
			.OrderBy(d => d.DeviceType)
			.ThenBy(d => d.DeviceID)
			.ToList();

		// Print devices with friendly names
		Console.WriteLine("\nDevice List ON, sorted:");
		foreach (var device in sortedOnDevices)
		{
			Console.WriteLine(device);
		}

		// From Example 3 of Exercise 1
		var orderedGroupedDevices = devices
			.OrderBy(d => d.DeviceType) // Order by DeviceType first
			.ThenBy(d => d.DeviceID)    // Then order by DeviceID within DeviceType
			.GroupBy(d => d.DeviceType)
			.Select(group => new
			{
				DeviceType = group.Key,
				OnCount = group.Count(d => d.Status.Equals("On", StringComparison.OrdinalIgnoreCase)),
				OffCount = group.Count(d => d.Status.Equals("Off", StringComparison.OrdinalIgnoreCase)),
				Devices = group.OrderBy(d => d.DeviceID).ToList() // Include sorted devices if needed
			});

		// Print devices with friendly names
		Console.WriteLine("\nDevice List by DeviceType and then DeviceID:");
		foreach (var group in orderedGroupedDevices)
		{
			Console.WriteLine($"Device Type: {group.DeviceType.ToFriendlyString()}");
			Console.WriteLine($"On Count: {group.OnCount}");
			Console.WriteLine($"Off Count: {group.OffCount}");
			
			if (group.Devices != null) // If you included the list of devices
			{
				Console.WriteLine("Devices:");
				foreach (var device in group.Devices)
				{
					Console.WriteLine($"\tDevice ID: {device.DeviceID}, Status: {device.Status}");
				}
			}

			Console.WriteLine(); // Blank line for better readability
		}
		
		#endregion
	}

	private static List<SmartDevice> LoadDevicesFromJson(string filePath)
	{
		string json = File.ReadAllText(filePath);
		return JsonSerializer.Deserialize<List<SmartDevice>>(json) ?? [];
	}
}
