# SOLID Principles

Five design principles that make software designs more understandable, flexible, and maintainable.

## 1. Single Responsibility Principle (SRP)
**Definition**: Each class should have only one reason to change (one responsibility).

```csharp
// BAD - Multiple responsibilities
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    
    public void Save() { /* Database logic */ }
    public void SendEmail() { /* Email logic */ }
    public string GenerateReport() { /* Report logic */ }
}

// GOOD - Single responsibility
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserRepository
{
    public void Save(User user) { /* Database logic */ }
}

public class EmailService
{
    public void SendEmail(User user) { /* Email logic */ }
}
```

## 2. Open-Closed Principle (OCP)
**Definition**: Classes should be open for extension but closed for modification.

```csharp
// GOOD - Open for extension
public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public override double CalculateArea() => Width * Height;
}

public class Circle : Shape
{
    public double Radius { get; set; }
    
    public override double CalculateArea() => Math.PI * Radius * Radius;
}

// Adding new shapes doesn't require modifying existing code
public class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }
    
    public override double CalculateArea() => 0.5 * Base * Height;
}
```

## 3. Liskov Substitution Principle (LSP)
**Definition**: Objects of a base class should be replaceable with objects of derived classes without breaking functionality.

```csharp
// GOOD - Derived classes can substitute base class
public abstract class Bird
{
    public abstract void Move();
}

public class Sparrow : Bird
{
    public override void Move() => Console.WriteLine("Flying");
}

public class Penguin : Bird
{
    public override void Move() => Console.WriteLine("Swimming");
}

// Both can be used interchangeably
Bird bird1 = new Sparrow();
Bird bird2 = new Penguin();
bird1.Move(); // Works
bird2.Move(); // Works
```

## 4. Interface Segregation Principle (ISP)
**Definition**: No code should be forced to depend on methods it doesn't use.

```csharp
// BAD - Fat interface
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

// GOOD - Segregated interfaces
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public class Human : IWorkable, IFeedable, ISleepable
{
    public void Work() { /* Implementation */ }
    public void Eat() { /* Implementation */ }
    public void Sleep() { /* Implementation */ }
}

public class Robot : IWorkable
{
    public void Work() { /* Implementation */ }
    // Robot doesn't need Eat() or Sleep()
}
```

## 5. Dependency Inversion Principle (DIP)
**Definition**: High-level modules should not depend on low-level modules. Both should depend on abstractions.

```csharp
// BAD - Direct dependency
public class OrderService
{
    private EmailService _emailService = new EmailService(); // Tight coupling
    
    public void ProcessOrder(Order order)
    {
        // Process order
        _emailService.SendConfirmation(order.CustomerEmail);
    }
}

// GOOD - Dependency inversion
public interface IEmailService
{
    void SendConfirmation(string email);
}

public class OrderService
{
    private readonly IEmailService _emailService;
    
    public OrderService(IEmailService emailService) // Dependency injection
    {
        _emailService = emailService;
    }
    
    public void ProcessOrder(Order order)
    {
        // Process order
        _emailService.SendConfirmation(order.CustomerEmail);
    }
}
```

## Benefits of SOLID
- **Maintainable**: Easier to modify and extend
- **Testable**: Components can be tested in isolation
- **Flexible**: Easy to adapt to changing requirements
- **Reusable**: Components can be reused in different contexts
- **Understandable**: Code is more readable and organized