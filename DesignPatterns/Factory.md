# Factory

The Factory Method design pattern allow us to define an interface for creating objects of a general base type without specifying the subtype of what will be created.

## Benefits
- Separates the creation of objects from using the objects. This is know as **Separation of Concern**.
- Less coupling
- Avoids code repetition

## Example

```csharp
// Base type
public abstract class Vehicle
{
    public abstract void Start();
}

// Concrete implementations
public class Car : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Car engine starting...");
    }
}

public class Motorcycle : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Motorcycle kick-starting...");
    }
}

public class Truck : Vehicle
{
    public override void Start()
    {
        Console.WriteLine("Truck diesel engine starting...");
    }
}

// Factory class
public static class VehicleFactory
{
    public static Vehicle CreateVehicle(string vehicleType)
    {
        return vehicleType.ToLower() switch
        {
            "car" => new Car(),
            "motorcycle" => new Motorcycle(),
            "truck" => new Truck(),
            _ => throw new ArgumentException($"Unknown vehicle type: {vehicleType}")
        };
    }
}

// Usage
string[] vehicleTypes = { "car", "motorcycle", "truck" };

foreach (string type in vehicleTypes)
{
    Vehicle vehicle = VehicleFactory.CreateVehicle(type);
    vehicle.Start();
}

// Output:
// Car engine starting...
// Motorcycle kick-starting...
// Truck diesel engine starting...
```

## Without Factory (Problems)

```csharp
// Client code has to know about all concrete types
public void CreateVehicles(string[] types)
{
    foreach (string type in types)
    {
        Vehicle vehicle;
        
        // Tight coupling - client knows all implementations
        if (type == "car")
            vehicle = new Car();
        else if (type == "motorcycle")
            vehicle = new Motorcycle();
        else if (type == "truck")
            vehicle = new Truck();
        else
            throw new ArgumentException($"Unknown type: {type}");
            
        vehicle.Start();
    }
}
```

## Key Benefits Demonstrated
- **Separation of Concerns**: Factory handles creation, client handles usage
- **Less Coupling**: Client doesn't know about concrete classes
- **No Repetition**: Creation logic centralized in one place
- **Easy Extension**: Add new vehicle types without changing client code


## Static Factory Method Design

Static Factory Methods are static methods within a class that return instances of that class. They provide an alternative to constructors with more descriptive names and flexible creation logic.

### Example

```csharp
public class Person
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public DateTime BirthDate { get; private set; }
    
    // Private constructor
    private Person(string name, int age, DateTime birthDate)
    {
        Name = name;
        Age = age;
        BirthDate = birthDate;
    }
    
    // Static factory methods with descriptive names
    public static Person CreateFromAge(string name, int age)
    {
        var birthDate = DateTime.Now.AddYears(-age);
        return new Person(name, age, birthDate);
    }
    
    public static Person CreateFromBirthDate(string name, DateTime birthDate)
    {
        var age = DateTime.Now.Year - birthDate.Year;
        return new Person(name, age, birthDate);
    }
    
    public static Person CreateBaby(string name)
    {
        return new Person(name, 0, DateTime.Now);
    }
}

// Usage
var person1 = Person.CreateFromAge("John", 25);
var person2 = Person.CreateFromBirthDate("Jane", new DateTime(1990, 5, 15));
var person3 = Person.CreateBaby("Baby Smith");
```

### Benefits of Static Factory Methods

1. **Descriptive Names**: Method names explain what they create
2. **Can Return Subclasses**: More flexible than constructors
3. **Can Cache/Reuse Instances**: Control object creation
4. **Validation Logic**: Can validate before creating objects

### Key Differences from Regular Factory
- **Location**: Methods are inside the class being created
- **Scope**: Creates instances of the same class
- **Purpose**: Alternative constructors with better names
- **Constructor**: Often makes constructors private
