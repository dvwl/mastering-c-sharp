---
lab:
    title: 'Generating, Partitioning, and Projecting Data in a Smart Home'
---
# Module 01c: Generating, Partitioning, and Projecting Data in a Smart Home
Your smart home system is expanding, and now you need to generate data, partition it into manageable sections, and project only relevant information to the user interface.

## Exercise 6: Generating Data for Testing
You’ve been asked to simulate a large batch of sensor data for testing purposes. Use LINQ to generate test data that represents a series of sensor readings over time.

**Instructions:**
1. Generate 100 sample sensor readings using LINQ.
2. Each reading should include data like `SensorID`, `Temperature`, and `Humidity`.

```csharp
public class SensorReading
{
    public int SensorID { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
}
```

## Exercise 7: Partitioning Device Data for Display
You need to display devices in pages on a dashboard, with each page showing 10 devices at a time. Use LINQ to partition the device list into pages.

**Instructions:**
1. Take the device list from previous exercises and add more devices.
2. Use LINQ to partition the list into pages, each containing 10 devices.
3. Display the first page and allow the user to navigate through the pages.

## Exercise 8: Projecting Device Details to the User Interface
Your system only needs to display a subset of information about each device on the dashboard, such as `DeviceID` and `Status`. Use LINQ projection to create a new collection with only the necessary fields.

**Instructions:**
1. Create a projection using LINQ that only selects `DeviceID` and `Status` from the list.
2. Display the result in a user-friendly format.

Happy exploring and I'll see you in the next Module!
