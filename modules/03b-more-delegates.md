---
lab:
    title: 'Mastering Delegates: Controlling a Robotics System +'
---
# Module 03b: Mastering Delegates: Controlling a Robotics System +
In this exercise module, we extend what we learnt in the previous module. You'll be again working on a space-themed exercise.

## Exercise 5: Evaluating Robot Components with Func, Action, and Predicate
In this exercise, you’ll leverage `Func`, `Action`, and `Predicate` delegates to evaluate various components of a robot and perform actions based on the evaluations. You will create a simple monitoring system that checks the status of the robot's battery, sensors, and motors.

**Instructions:**
1. Define a `Predicate` to evaluate the status of the battery (e.g., whether it is low).
2. Define an `Action` to alert the user when any component (battery, sensors, or motors) is malfunctioning.
3. Define a `Func` that calculates the overall health score of the robot based on the performance of its components.
4. Create and implement the `RobotMonitor` class.

Example Program:
```csharp
class Program
{
    static void Main()
    {
        RobotMonitor monitor = new();

        int batteryLevel = 15; // Example battery level
        bool sensorsFunctional = true;
        bool motorsFunctional = false;

        // Check battery status
        Predicate<int> batteryCheck = monitor.IsBatteryLow;
        if (batteryCheck(batteryLevel))
        {
            monitor.Alert("Battery level is low!");
        }

        // Check sensor and motor functionality
        if (!sensorsFunctional)
        {
            monitor.Alert("Sensors are malfunctioning!");
        }
        if (!motorsFunctional)
        {
            monitor.Alert("Motors are malfunctioning!");
        }

        // Calculate health score
        Func<int, bool, bool, int> healthScoreFunc = monitor.CalculateHealthScore;
        int healthScore = healthScoreFunc(batteryLevel, sensorsFunctional, motorsFunctional);
        Console.WriteLine($"Overall Health Score: {healthScore}");
    }
}
```

**Expected Outcome:**
- You should be able to evaluate the robot's battery status, alert the user of any component malfunctions, and calculate the overall health score of the robot. This exercise reinforces the utility of Func, Action, and Predicate in a practical scenario.
