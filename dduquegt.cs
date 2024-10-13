using System;

// Base class: Vehicle
public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }

    public void StartEngine()
    {
        Console.WriteLine("Engine started");
    }

    public void StopEngine()
    {
        Console.WriteLine("Engine stopped");
    }
}

// Derived class: Car (inherits from Vehicle)
public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    // Method specific to Car class
    public void Honk()
    {
        Console.WriteLine("Car horn goes beep beep!");
    }

    // Method overriding the base class StartEngine method
    public new void StartEngine()
    {
        Console.WriteLine("Car engine started with a roar!");
    }
}

// Testing the classes
public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of the Car class
        Car myCar = new Car();
        myCar.Make = "Nissan";
        myCar.Model = "Lexus";
        myCar.NumberOfDoors = 4;

        // Call methods from both the base and derived class
        myCar.StartEngine(); // Overridden method in Car class
        myCar.Honk();        // Car-specific method
        myCar.StopEngine();   // Inherited method from Vehicle class

        // Output basic car details
        Console.WriteLine("Make: {myCar.Make}, Model: {myCar.Model}, Doors: {myCar.NumberOfDoors}");
    }