namespace answers.models;

public enum DeviceType
{
	GenericDevice,
	SmartCamera,
	SmartDoorLock,
	SmartFridge,
	SmartLight,
	SmartThermostat,
	SmartWasher
}

public class SmartDevice
{
	public int DeviceID { get; set; }
	public DeviceType DeviceType { get; set; }
	public string? Status { get; set; }

	// A pure functional approach
	public override string ToString() 
		=> $"ID: {DeviceID}, Type: {string.Concat(
			DeviceType.ToString()
			.Select((c, i) => i > 0 && char.IsUpper(c) ? $" {c}" : $"{c}")
		)}, Status: {Status}";
}