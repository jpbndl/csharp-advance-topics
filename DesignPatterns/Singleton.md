# Singleton Design Pattern

Singleton is a class that only allows creating a single instance of itself. Singleton uses a **private** access modifier for its constructor.

Singleton is having a **Global State**.

## Example

```csharp
public class DatabaseConnection
{
    private static DatabaseConnection _instance;
    
    // Private constructor prevents external instantiation
    private DatabaseConnection()
    {
        Console.WriteLine("Database connection created");
    }
    
    // Public method to get the single instance
    public static DatabaseConnection GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DatabaseConnection();
        }
        return _instance;
    }
    
    public void Connect()
    {
        Console.WriteLine("Connected to database");
    }
}

// Usage
var db1 = DatabaseConnection.GetInstance();
var db2 = DatabaseConnection.GetInstance();

Console.WriteLine(db1 == db2); // True - same instance

// var db3 = new DatabaseConnection(); // ERROR! Constructor is private
```

## Key Points
- Private constructor prevents `new` keyword usage
- Static field holds the single instance
- Static method provides controlled access
- All references point to the same object

## Why Singleton is an Antipattern

### 1. Global State Problem
Global state is globally accessible throughout the entire application. That means that any other class can access it and modify it.

```csharp
public class Logger
{
    private static Logger _instance;
    public string LogLevel { get; set; } = "INFO";
    
    public static Logger GetInstance()
    {
        if (_instance == null) _instance = new Logger();
        return _instance;
    }
}

// Problem: Any class can modify the global state
class ServiceA
{
    public void DoWork()
    {
        Logger.GetInstance().LogLevel = "DEBUG";  // Changes global state!
    }
}

class ServiceB
{
    public void DoWork()
    {
        var logger = Logger.GetInstance();
        // Expects "INFO" but gets "DEBUG" - unexpected behavior!
    }
}
```

### 2. Testing Difficulties
```csharp
// Hard to test because of shared state
[Test]
public void Test1()
{
    var logger = Logger.GetInstance();
    logger.LogLevel = "ERROR";
    // Test logic...
}

[Test]
public void Test2()
{
    var logger = Logger.GetInstance();
    // This test might fail because Test1 changed the state!
    Assert.AreEqual("INFO", logger.LogLevel); // May fail!
}
```

### 3. Hidden Dependencies
```csharp
public class OrderService
{
    public void ProcessOrder(Order order)
    {
        // Hidden dependency - not visible in constructor
        var db = DatabaseConnection.GetInstance();
        db.Save(order);
    }
}

// Hard to see what dependencies OrderService needs
// Makes unit testing difficult
```

### 4. Violates Single Responsibility
Singleton classes often do two things:
- Manage their own lifecycle (creation/destruction)
- Perform their actual business logic

## Better Alternatives

### Dependency Injection
```csharp
public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message) { /* implementation */ }
}

public class OrderService
{
    private readonly ILogger _logger;
    
    // Dependencies are explicit and testable
    public OrderService(ILogger logger)
    {
        _logger = logger;
    }
}

// In DI container configuration
services.AddSingleton<ILogger, FileLogger>();  // DI manages singleton lifecycle
```

**Problems with Singleton:**
- Creates hidden global state
- Makes testing difficult
- Hides dependencies
- Violates Single Responsibility Principle
- Hard to extend or modify

**Use DI instead** - it provides the benefits without the drawbacks!
