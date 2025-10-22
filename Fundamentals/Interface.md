# Interface

An interface defines a contract that implementing classes must follow.

## Key Features
- Cannot be instantiated directly
- All members are public by default
- Can contain methods, properties, events, and indexers
- Classes can implement multiple interfaces
- Supports inheritance between interfaces
- No implementation details (contract only)

## Basic Example
```csharp
public interface ICalculator
{
    double Calculate(double a, double b);
    string Operation { get; }
}

public class AddCalculator : ICalculator
{
    public string Operation => "Addition";
    
    public double Calculate(double a, double b)
    {
        return a + b;
    }
}

public class MultiplyCalculator : ICalculator
{
    public string Operation => "Multiplication";
    
    public double Calculate(double a, double b)
    {
        return a * b;
    }
}
```

## Real-World Example: File Processing

```csharp
// Interface contract
public interface IFileProcessor
{
    void ProcessFile(string filePath);
    bool CanProcess(string fileExtension);
}

// Different implementations
public class PdfProcessor : IFileProcessor
{
    public bool CanProcess(string fileExtension)
    {
        return fileExtension.ToLower() == ".pdf";
    }
    
    public void ProcessFile(string filePath)
    {
        Console.WriteLine($"Processing PDF: {filePath}");
    }
}

public class ImageProcessor : IFileProcessor
{
    public bool CanProcess(string fileExtension)
    {
        return fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png";
    }
    
    public void ProcessFile(string filePath)
    {
        Console.WriteLine($"Processing Image: {filePath}");
    }
}

// Usage with polymorphism
public class FileManager
{
    private readonly List<IFileProcessor> _processors;
    
    public FileManager()
    {
        _processors = new List<IFileProcessor>
        {
            new PdfProcessor(),
            new ImageProcessor()
        };
    }
    
    public void ProcessFile(string filePath)
    {
        string extension = Path.GetExtension(filePath);
        
        foreach (var processor in _processors)
        {
            if (processor.CanProcess(extension))
            {
                processor.ProcessFile(filePath);
                return;
            }
        }
        
        Console.WriteLine($"No processor found for {extension}");
    }
}
```

## Multiple Interface Implementation

```csharp
public interface IReadable
{
    string Read();
}

public interface IWritable
{
    void Write(string content);
}

// Class implementing multiple interfaces
public class TextFile : IReadable, IWritable
{
    private string _content = "";
    
    public string Read()
    {
        return _content;
    }
    
    public void Write(string content)
    {
        _content = content;
    }
}
```

## Interface vs Abstract Class

| Interface | Abstract Class |
|-----------|----------------|
| Contract only | Can have implementation |
| Multiple inheritance | Single inheritance |
| All members public | Can have private/protected |
| No constructors | Can have constructors |
| No fields | Can have fields |

## Testability Example

```csharp
// Interface for external dependency
public interface IEmailService
{
    bool SendEmail(string to, string subject, string body);
}

// Production implementation
public class EmailService : IEmailService
{
    public bool SendEmail(string to, string subject, string body)
    {
        // Actual email sending logic
        Console.WriteLine($"Sending email to {to}");
        return true;
    }
}

// Service that depends on IEmailService
public class UserService
{
    private readonly IEmailService _emailService;
    
    public UserService(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    public bool RegisterUser(string email, string name)
    {
        // Registration logic
        Console.WriteLine($"Registering user: {name}");
        
        // Send welcome email
        return _emailService.SendEmail(email, "Welcome!", $"Hello {name}");
    }
}

// Unit test with mock
public class UserServiceTests
{
    [Test]
    public void RegisterUser_ShouldSendWelcomeEmail()
    {
        // Arrange - Create mock
        var mockEmailService = new Mock<IEmailService>();
        mockEmailService.Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                       .Returns(true);
        
        var userService = new UserService(mockEmailService.Object);
        
        // Act
        var result = userService.RegisterUser("test@email.com", "John");
        
        // Assert
        Assert.IsTrue(result);
        mockEmailService.Verify(x => x.SendEmail("test@email.com", "Welcome!", "Hello John"), Times.Once);
    }
}
```

## Why Use Interfaces?

- **Loose Coupling**: Classes depend on contracts, not implementations
- **Testability**: Easy to mock interfaces for unit testing
- **Flexibility**: Swap implementations without changing client code
- **Multiple Inheritance**: Classes can implement multiple interfaces
- **Polymorphism**: Treat different objects uniformly through common interface

## Best Practices

- Keep interfaces small and focused (Interface Segregation Principle)
- Use descriptive names with 'I' prefix (e.g., `IFileProcessor`)
- Avoid changing existing interfaces (create new ones instead)
- Prefer composition over inheritance when possible