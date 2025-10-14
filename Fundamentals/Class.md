# Class

- Consist of data (fields) and behaviour (method/functions)
- Reference types
    - Inherit from System.Object
    - Passed by reference
    - Support inheritance
    - Stored on the heap
- Can have destructors/finalizers - called by garbage collector removes an object from memory
- No parameterless constructor unless explicitly defined
- Support polymorphism and virtual methods

## Table of Contents
- [Class Members](#class-members)
  - [Instance](#instance)
  - [Static](#static)
- [Constructors](#constructors)
- [Object Initializers](#object-initializers)
- [Class Couping](#class-coupling)
- [Partial Class](#partial-class)
- [Static Class](#static-class)
- [new Keyword](#new-keyword)
- [static Keyword](#static-keyword)
- [Structs](#structs)

## Class Members

### Instance

Instance is accessible from an object
```csharp
var person = new Person();
person.Introduce();
```

### Static 
Static is accessible from the class itself. It is used to represent concepts that are **singleton**
```csharp
DateTime.Now();
Console.WriteLine();
```

## Constructors

A constructor is method that is called when an instance of a class is created. This puts an object created from the class in initial state.

```csharp
public class Address {
    public string City;
}

public class Person {
    public string Name;
    public List<Address> Addresses;

    public Person() {
        /**  
            If it happens that there is any list in the class,
            Always initialize it to empty list.
            The caller of this class should not be responsible for initializing it or handling the NullReferenceException.

            See Fields.md for much better approach.
        */
        Addresses = new List<Address>();
    }

    /** 
        Constructors can be overloaded by using different signature
        Signature is what uniquely identifies a method by its name parameters, and return type.
    
        Using this() will call the constructor public Person() which will initialize the list
        instead of typing Address = new List<Address>();
    */ 
    public Person(string name) : this() 
    {
        this.Name = name;
    }
    
    public Person(int id, string name) : this()  {
        this.Name = name;
    }
}

var person = new Person("JP");
var person2 = new Person(1, "JP");
```

## Object Initializers
A syntax for quickly initialising an object without the need to call one of its constructors. 

```csharp
var person = new Person {
    Name = "JP"
};
```

## Class Coupling
Coupling is a measure of how interconnected classes and subsystems are.

### Tightly Coupled (Bad) 🔴

```
┌─────────┐    ┌─────────┐    ┌─────────┐
│ OrderUI │───▶│ Order   │───▶│Database │
└─────────┘    │Service  │    │Helper   │
               └─────────┘    └─────────┘
                    │
                    ▼
               ┌─────────┐
               │EmailSvc │
               └─────────┘
```

```csharp
// Tightly coupled - BAD
public class OrderService
{
    public void ProcessOrder(Order order)
    {
        // Direct dependencies - hard to test/change
        var dbHelper = new DatabaseHelper();
        var emailService = new EmailService();
        
        dbHelper.SaveOrder(order);
        emailService.SendConfirmation(order.CustomerEmail);
    }
}
```

### Loosely Coupled (Good) 🟢

```
┌─────────┐    ┌─────────┐    ┌──────────┐
│ OrderUI │───▶│ Order   │───▶│IDatabase │
└─────────┘    │Service  │    │Repository│
               └─────────┘    └──────────┘
                    │
                    ▼
               ┌──────────┐
               │IEmailSvc │
               └──────────┘
```

```csharp
// Loosely coupled - GOOD
public class OrderService
{
    private readonly IDatabaseRepository _database;
    private readonly IEmailService _emailService;
    
    // Dependencies injected - easy to test/change
    public OrderService(IDatabaseRepository database, IEmailService emailService)
    {
        _database = database;
        _emailService = emailService;
    }
    
    public void ProcessOrder(Order order)
    {
        _database.SaveOrder(order);
        _emailService.SendConfirmation(order.CustomerEmail);
    }
}
```

### Benefits of Loose Coupling
- **Testable**: Easy to mock dependencies
- **Flexible**: Can swap implementations
- **Maintainable**: Changes don't ripple through system
- **Reusable**: Components work independently

## Class Relationships

### Inheritance
A relationship between two classes that allows one to inherit code from the other
```
ServiceProvider -> Google
Printer -> HP
```

**Benefits**
- Code-reuse
- Polymorphism

**Example**
```csharp
// Parent / base class
public class PresentationObject {
    public int width { get; set; }
    public int height { get; set; }

    public void Copy() {
        Console.WriteLine("Copy to clipboard")
    }
}

public class Text : PresentationObject {
    public int FontSize { get; set; }
    public string FontName { get; set; }

    public void AddHyperLink(string url) {
        Console.WriteLine("Added hyperlink: " + url);
    }
}
```

**📝 NOTE:** A child class can only inherit one base class.

### Composition
A relationship between two classes that allows one to contain the other

**Benefits**
- Code re-use
- Flexibility
- Loose-coupling

**Example**

```csharp
public class Logger {
    public function Log() {
        Console.WriteLine("Logging using logger")
    }
}

public class DbMigration {
    private readonly Logger _logger;
    public DBMigration(Logger logger) {
        _logger = logger;
    }

    public void Migrate(string message) {
        _logger.Log("Logging using logger + " message)
    }
}

public class Installer {
    private readonly Logger _logger;
    public DBMigration(Logger logger) {
        _logger = logger;
    }

    public void Install(string message) {
        _logger.Log("Logging using logger + " message)
    }
}
```

### Composition vs Inheritance 

**Inheritance**
- Easily abused by amateur designers / developers
- Large hierarchies
- Fragility
- Tighlty coupled

**Composition**
- Any inheritance relationship can be translated to Composition

## Partial Class

Partial classes are clases that are split into multiple source files. All the partial classes will be combined during the compilation. Partial can also be implemented in structs, intefaces and methods.

```csharp
partial class Helpers {
    private void Log() {}
}

partial class Helpers {
    private void Notify() {}
}
```

### Partial Use Case
This can be used when the class is too large and too many developers are working on the same class.

## Static Class

A static class is a class that cannot be instantiated and can only contain static methods and members. It can work as a container for static methods.

### Working Example
```csharp
public static class MathHelper
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
    
    public static double Pi = 3.14159;
}

// Usage
int result = MathHelper.Add(5, 3);  // Works fine
double pi = MathHelper.Pi;          // Works fine
```

### Not Working Example
```csharp
public static class MathHelper
{
    public int instanceField;           // ERROR! Cannot have instance members
    
    public void InstanceMethod() { }    // ERROR! Cannot have instance methods
    
    public MathHelper() { }             // ERROR! Cannot have constructors
}

// Usage
var helper = new MathHelper();      // ERROR! Cannot instantiate static class
```

```csharp
public static class MathHelper
{
    static int _total;

    static MathHelper(int total) { // ERROR! Cannot have parameters
        _total = total; 
    }
}
```

```csharp
public static class MathHelper
{
    int _total;

    static MathHelper() { 
        _total = 0; // ERROR! A static constructor can only operate on static members of a class
    }
}
```

**Rules for Static Classes:**
- All members must be static
- Cannot be instantiated
- Cannot have constructors
- Cannot inherit from other classes
- Cannot be inherited
- We can't use `this` keyword because `this` refers to the current instance 

**Rules for constructor in a Static clas**
- It must be parameterless
- It cannot have access modifiers
- It cannot be inherited or overloaded
- It cannot be called directly

## `new` keyword

The `new` keyword is used in **operator**, **modifier**, and **constraint**

### Example
```csharp
public class SampleClass<T> where T : new() {
    private T _val;
    public T Get() {
        if (_val == null) {
            // without the constraint where T : new(), this will get an error since it does not 
            // know where T requires an argument
            _val = new T();
        }
        return _val;
    }
    public T Set() { }
}
```

## `static` keyword

The static keyword can be used to declare static **class (including its member)**, **structs** and **records**. In class, static members belongs to a class as a whole, not to an instance.

Static modifier can be applied to: 
- Fields, properties, methods, constructors, events, operators, and local functions

**Notes**
**You cannot have a static structs**
**A static method cannot refernce non-static members as it is not aware of the non-static fields.**

Static can be accessed by:
```csharp
public class Helper {
    public static int count; 
}
Helper.count // accessing via the class, not instance

using static System.Helper; // using a static directive
count
```

### Example
```csharp
public class Helper {
    public static int count;
}

var helperInstance = new Helper();
helperInstance.count; // This will produced an error as static members belong to a type itself not to a specific instance
Helper.count; // This is the correct way to access the static members
```

```csharp
public class Helper {
    public static int count;

    public int GetCount() {
        // This will work since count is part of the class Helper
        var c = count;
    }

    public static string readCount() {
        return $"Count: {count}";
    }
}
```

### What will be the output of the code below?
```csharp
class Counter {
    static int Value;

    public void IncrementValue() {
        Value++;
    }

    public int GetValue() {
        return Value;
    }
}
using static System.Console;

class Program {
    static void Main(string[] args) {
        var ctr1 = new Counter();
        ctr1.IncrementValue();
        ctr1.IncrementValue(); 

        var ctr2 = new Counter();
        ctr2.IncrementValue(); 

        Writeline($"ctr1 : {ctr1.GetValue()}");
        Writeline($"ctr2 : {ctr2.GetValue()}");
    }
}

// Output: 
// ctr1: 3
// ctr2: 3
// Static fields belong to the class itself, not individual instances, so all instances share the same Value variable. // Both ctr1 and ctr2 see the same value of 3
```
### Can GetItems be made static?

```csharp
class Helper {
    private List<Items> _items;
    public void GetItems() {
        Writeline($"items: {_items}")
    }
}

// Answer: No
// GetItems method uses the non-static _items field.
// Static methods belong to the class itself, not to any specific instance
// Instance fields (_items) belong to individual instances
// Static methods don't know which instance's _items to access
```

## Structs
- Value types
    - Inhertis from System.ValueType
    - Passed by copy
    - Are sealed
    - Stored on the stack
- Do not support inheritance but can implement interfaces
- Cannot have destructors
- Always have a parameterless constructor even if it is not defined explicitly

```csharp
public struct Point {
    public int x;
    public int y;

    // can be defined without this
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
// This will work without any errors
var point = new Point();
```

```csharp
public class Point {
    public int x;
    public int y;

    // can be defined without this
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

// This will cause an error as no arguments are supplied
var point = new Point();
```