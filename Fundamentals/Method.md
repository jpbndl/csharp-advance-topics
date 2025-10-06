# Method

A method is a block of code that performs a specific task. Methods allow you to organize code into reusable units.

## Virtual method
A Virtual method is a method that might be overridden in inheriting class.

### Example
```csharp
public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks: Woof!");
    }
}

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Cat meows: Meow!");
    }
}

// Usage
Animal animal = new Animal();
Animal dog = new Dog();
Animal cat = new Cat();

animal.MakeSound(); // "Animal makes a sound"
dog.MakeSound();    // "Dog barks: Woof!"
cat.MakeSound();    // "Cat meows: Meow!"
```

**Key Points:**
- Base class uses `virtual` keyword
- Derived class uses `override` keyword
- Polymorphism: correct method called at runtime based on actual object type

## Abstract method

An abstract method is a method declared without implementation. It **must** be overridden in derived classes (unless the derived class is abstract itself). Abstract methods can only exist in abstract classes.

### Example
```csharp
public abstract class Shape
{
    // Abstract method - no implementation
    public abstract double CalculateArea();
    
    // Regular method with implementation
    public void Display()
    {
        Console.WriteLine($"Area: {CalculateArea()}");
    }
}

public class Circle : Shape
{
    private double radius;
    
    public Circle(double radius)
    {
        this.radius = radius;
    }
    
    // Must override abstract method
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

public class Rectangle : Shape
{
    private double width, height;
    
    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }
    
    // Must override abstract method
    public override double CalculateArea()
    {
        return width * height;
    }
}

// Usage
// Shape shape = new Shape(); // ERROR! Cannot instantiate abstract class
Shape circle = new Circle(5);
Shape rectangle = new Rectangle(4, 6);

circle.Display();    // "Area: 78.54"
rectangle.Display(); // "Area: 24"
```

### Code Analysis Example

```csharp
abstract class Base {
    public virtual void Print() {
        Console.WriteLine("Im a base class");
    }
}

class Derived : Base {
    public virtual void Print() {  // ERROR! Should be 'override'
        Console.WriteLine("Im a derived class");
    }
}

class Program {
    static void Main(strings[] args) {  
        Base baseObj = new Base();     // ERROR! Cannot instantiate abstract class
        Base d1 = new Derived();      // OK
        Derived d2 = new Derived();   // OK
    }
}
```

**Compilation Errors:**
2. **Line 16**: Cannot instantiate abstract class `Base` with `new Base()`
3. **Line 9**: `Derived.Print()` should use `override`, not `virtual` (hides base method instead of overriding)

**Corrected Version:**
```csharp
abstract class Base {
    public virtual void Print() {
        Console.WriteLine("Im a base class");
    }
}

class Derived : Base {
    public override void Print() {  // Fixed: override instead of virtual
        Console.WriteLine("Im a derived class");
    }
}

class Program {
    static void Main(string[] args) {  // Fixed: string[] instead of strings[]
        // Base baseObj = new Base();  // Removed: Cannot instantiate abstract class
        Base d1 = new Derived();
        Derived d2 = new Derived();
        
        d1.Print();  // "Im a derived class"
        d2.Print();  // "Im a derived class"
    }
}
```
**Key Points:**
- Abstract methods have no implementation (no body)
- Must be declared in abstract classes
- Derived classes **must** override abstract methods
- Cannot instantiate abstract classes directly
- Forces consistent interface across derived classes
- **Static methods cannot be virtual or abstract** (static belongs to class, not instance)

## Method Overloading
Method overloading is having a class with multiple methods with the same name, that have different parameters.

### Working Example

```csharp
public class Calculator
{
    // Same method name, different parameters
    public int Add(int a, int b)
    {
        return a + b;
    }
    
    public double Add(double a, double b)
    {
        return a + b;
    }
    
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
}

// Usage
var calc = new Calculator();

int result1 = calc.Add(5, 3);           // Calls Add(int, int) → 8
double result2 = calc.Add(5.5, 3.2);    // Calls Add(double, double) → 8.7
int result3 = calc.Add(1, 2, 3);        // Calls Add(int, int, int) → 6
```

### Not Working Example

```csharp
public string Merge(string str1, string str2) {
    return str1 + str2;
}

public string[] Merge(string str1, string str2) {
    return new string[] { str1, str2 }; // ERROR! We cannot have two method with the same signature which only differ in 
                                        // the returned type
}
```
**Key Points:**
- Same method name with different parameter types or counts
- Compiler determines which method to call based on arguments
- Return type alone cannot distinguish overloaded methods

## Method Overriding vs Method Hiding

**Method overriding** happens when the derived class provides its own implementation of a virtual or abstract method from a base class.

**Method Hiding** happens when there is a method in the derived class with the same name as the method in the base class that does not override the base class method.

### Method Overriding Example
```csharp
public class Vehicle
{
    public virtual void Start()
    {
        Console.WriteLine("Vehicle starting...");
    }
}

public class Car : Vehicle
{
    public override void Start()  // Overriding
    {
        Console.WriteLine("Car engine starting...");
    }
}

// Usage
Vehicle vehicle = new Car();
vehicle.Start();  // "Car engine starting..." (polymorphism works)
```

### Method Hiding Example
```csharp
public class Vehicle
{
    public virtual void Start()
    {
        Console.WriteLine("Vehicle starting...");
    }
}

public class Motorcycle : Vehicle
{
    public new void Start()  // Hiding (not overriding)
    {
        Console.WriteLine("Motorcycle kick-starting...");
    }
}

// Usage
Vehicle vehicle = new Motorcycle();
vehicle.Start();  // "Vehicle starting..." (base method called!)

Motorcycle bike = new Motorcycle();
bike.Start();     // "Motorcycle kick-starting..." (derived method called)
```

**Key Differences:**
- **Override**: Uses `override` keyword, enables polymorphism
- **Hiding**: Uses `new` keyword, breaks polymorphism
- **Override**: Derived method called through base reference
- **Hiding**: Base method called through base reference
