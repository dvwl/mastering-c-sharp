---
lab:
    title: 'Elements, Joins, and Set Operations in a Smart Home'
---
# Module 01b: Elements, Joins, and Set Operations in a Smart Home
Your smart home system stores device information in multiple places: one list for devices and another for device diagnostics. You must join these lists and query data efficiently.

## Exercise 3: Finding a Specific Device
Using LINQ, locate a specific device by its `DeviceID`. For example, you may need to find the thermostat with `DeviceID = 101`.

**Instructions:**
1. Use LINQ to find and return the specific device from your list.
2. Display the device details if found; otherwise, show a message indicating it wasn’t found.

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

## Exercise 4: Joining Devices with Diagnostics
Your system collects diagnostic information for each device (e.g., error codes, battery status). This data is stored in a separate list. You need to join the device list with the diagnostics list based on the `DeviceID`.

**Instructions:**
1. Create two lists: one for `SmartDevice` and one for `DeviceDiagnostics`.
2. Use LINQ to perform an inner join between the two lists, matching on `DeviceID`.
3. Display a report showing the device and its corresponding diagnostic data.

Example `DeviceDiagnotics`:
```csharp
public class DeviceDiagnostics
{
    public int DeviceID { get; set; }
    public string ErrorCode { get; set; }
    public int BatteryStatus { get; set; } // Battery status as a percentage
}

// Initialize the list of diagnostics
List<DeviceDiagnostics> diagnostics =
[
    new DeviceDiagnostics { DeviceID = 1, ErrorCode = "E01", BatteryStatus = 85 },
    new DeviceDiagnostics { DeviceID = 2, ErrorCode = "E02", BatteryStatus = 50 },
    new DeviceDiagnostics { DeviceID = 3, ErrorCode = "E01", BatteryStatus = 100 },
    new DeviceDiagnostics { DeviceID = 4, ErrorCode = "E03", BatteryStatus = 90 },
];
```

**Example Output:**
```bash
Device Diagnostics Report:
DeviceID: 1, Type: Smart Light, Status: On, Error: E01, Battery: 85%
DeviceID: 2, Type: Smart Thermostat, Status: Off, Error: E02, Battery: 50%
DeviceID: 3, Type: Smart Camera, Status: On, Error: E01, Battery: 100%
DeviceID: 4, Type: Smart Door Lock, Status: Off, Error: E03, Battery: 90%
```

## Exercise 5: Identifying Devices with Unique Errors
Some devices are reporting errors that don't occur in others. Use LINQ's set operations to find devices with unique error codes.

**Instructions:**
1. Create a list of unique error codes from `DeviceDiagnostics`.
2. Use LINQ to identify which devices have unique errors.
3. Display the devices with their respective error codes.

**Tips:**
Use the set operators such as Except, Intersect, and Distinct, however, GroupBy operator may be easier and more efficient. 
Well, at this point, we have yet to discuss GroupBy operator. 
Perhaps, you'll circle back to this exercise and implement with GroupBy and observe the difference.

Stay curious and keep experimenting!
