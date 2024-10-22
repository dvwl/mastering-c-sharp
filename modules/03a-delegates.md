---
lab:
    title: 'Mastering Delegates: Controlling a Robotics System'
---
# Module 03a: Mastering Delegates: Controlling a Robotics System
In this module, you'll explore the power of delegates by creating a simple robotics control system. You'll learn how to use delegates to handle different actions, such as sensor inputs, motor control, and system alerts, with flexibility and modularity.

## Exercise 1: Basic Delegate for Motor Control
Your first task is to create a basic delegate that simulates controlling a robot’s motor. You'll use delegates to define actions like starting, stopping, and adjusting motor speed.

**Instructions:**
1. Define a delegate `MotorAction` that takes an `integer` representing motor speed.
2. Create methods to start the motor, stop the motor, and adjust the speed.
3. Use the delegate to call these methods based on different scenarios.

Class Example:
```csharp
public delegate void MotorAction(int speed);

class MotorController
{
    public void StartMotor(int speed) { /* Start motor logic */ }
    public void StopMotor(int speed) { /* Stop motor logic */ }
    public void AdjustSpeed(int speed) { /* Adjust speed logic */ }
}
```

**Expected Outcome:**
- You should be able to start, stop, and adjust motor speed using delegates, reinforcing how they allow flexible function calls.

## Exercise 2: Multicast Delegate for Sensor Monitoring
Now, extend your knowledge by creating a multicast delegate that triggers multiple sensor checks in the robot (e.g., temperature, proximity, or battery levels).

**Instructions:**
1. Create a delegate SensorCheck that doesn’t take any parameters.
2. Create methods for different sensors: checking temperature, proximity, and battery.
3. Use a multicast delegate to call all the sensor checks at once.

```csharp
class RobotSensors
{
    public void CheckTemperature() { /* Temperature logic */ }
    public void CheckProximity() { /* Proximity logic */ }
    public void CheckBattery() { /* Battery logic */ }
	/* and so on */
}
```

**Expected Outcome:**
- You should be able to trigger all the sensor checks using one multicast delegate, illustrating how multicast delegates can bundle multiple method calls.

## Exercise 3: Anonymous Methods for Custom Actions
Explore how anonymous methods can simplify your code when handling custom actions in the robot control system.

**Instructions:**
1. Use an anonymous method within a delegate to create a quick system alert (e.g., overheating alert).
2. Call the anonymous method whenever a condition (e.g., high temperature) is met.

```csharp
MotorAction alert = delegate(int temp)
{
    if (temp > 100)
        Console.WriteLine("Overheating! Shutting down motor.");
};
```

**Expected Outcome:**
- The alert should trigger when the temperature exceeds the limit, showcasing how anonymous methods provide flexibility for on-the-fly functionality.

## Exercise 4: Instance and Static Methods with Delegates
Explore the difference between instance and static methods by applying them to robot control tasks.

**Instructions:**
1. Create both instance and static methods for controlling the robot's arms.
2. Assign them to the delegate ArmControl, and test how both types of methods work.

```csharp
public delegate void ArmControl();
class RobotArms
{
    public void MoveArms() { /* Instance method */ }
    public static void ResetArms() { /* Static method */ }
}
```

**Expected Outcome:**
- You’ll understand how delegates can refer to both instance and static methods, demonstrating their versatility in real-world applications.
- Make a note on which method do you prefer (clearer?, cleaner?, efficient?).

## Key Takeaways
- Delegates provide a flexible way to reference and execute methods.
- Multicast delegates allow multiple methods to be called in one operation, simplifying complex systems like robotics.
- Anonymous methods make your code more concise when defining quick, custom behavior.

Enjoy controlling your robotic systems with the power of delegates!
