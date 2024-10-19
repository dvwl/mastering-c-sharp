---
lab:
    title: 'Sorting and Filtering Data in a Smart Home'
---
# Module 01a: Sorting and Filtering Data in a Smart Home
Imagine you are tasked with managing a fleet of smart devices (lights, sensors, thermostats) for a smart home system. Your job is to organize and filter the data to make it easier for the system to decide which devices need attention.

## Exercise 1: Filtering Devices by Status
Your smart home system has various devices, each with different statuses (e.g., "On", "Off", "Idle"). You need to filter out the devices that are currently "Off" to avoid unnecessary processing.

**Instructions:**
1. Create a list of devices with properties such as `DeviceID`, `DeviceType`, and `Status`.
2. Use LINQ to filter devices that are "On" or "Off" and print their details.

```csharp
// Sample Data Structure
public class SmartDevice {
    public int DeviceID { get; set; }
    public string DeviceType { get; set; }
    public string Status { get; set; }
}

// Example device list initialization and LINQ filtering
List<SmartDevice> devices =
[
    new SmartDevice { DeviceID = 1, DeviceType = "Smart Light", Status = "On" },
    new SmartDevice { DeviceID = 2, DeviceType = "Smart Thermostat", Status = "Off" },
    new SmartDevice { DeviceID = 3, DeviceType = "Smart Camera", Status = "On" },
    new SmartDevice { DeviceID = 4, DeviceType = "Smart Door Lock", Status = "Off" },
    new SmartDevice { DeviceID = 5, DeviceType = "Smart Thermostat", Status = "On" },
    new SmartDevice { DeviceID = 6, DeviceType = "Smart Light", Status = "On" }
];
```

## Exercise 2: Sorting Devices by Type and Priority
Next, you'll sort the filtered devices by their type (e.g., lights, thermostats) and by priority, which is determined by the device type (thermostats have higher priority than lights).

**Instructions:**
1. Take the filtered list from Exercise 1.
2. Sort the list first by `DeviceType` and then by `DeviceID`.

Example priority function:
```csharp
// Method to define device type priority (thermostats have the highest priority)
public static int GetDevicePriority(string deviceType)
{
    switch (deviceType)
    {
        case "Smart Thermostat":
            return 2; // Highest priority
        case "Smart Light":
            return 1; // Lower priority
        default:
            return 0; // Default priority for other devices
    }
}
```

Happy coding!
