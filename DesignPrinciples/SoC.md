# SoC (Separation of Concerns)

A design principle for separating a computer program into distinct sections, where each section addresses a separate concern.

## Key Concepts

- **Isolate functionality**: Each section handles one specific responsibility
- **Manage complexity**: Break down complex systems into manageable parts
- **Improve maintainability**: Changes in one concern don't affect others
- **Enable reusability**: Separated concerns can be reused independently

## Examples of Separation

### 1. MVC Pattern
```csharp
// Model - Data concern
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

// View - Presentation concern
public class UserView
{
    public void DisplayUser(User user)
    {
        Console.WriteLine($"Name: {user.Name}, Email: {user.Email}");
    }
}

// Controller - Logic concern
public class UserController
{
    private readonly UserService _userService;
    private readonly UserView _userView;
    
    public void ShowUser(int userId)
    {
        var user = _userService.GetUser(userId);
        _userView.DisplayUser(user);
    }
}
```

### 2. Service Layer Separation
```csharp
// Data Access Concern
public class UserRepository
{
    public User GetById(int id) { /* Database logic */ }
    public void Save(User user) { /* Database logic */ }
}

// Business Logic Concern
public class UserService
{
    private readonly UserRepository _repository;
    
    public User CreateUser(string name, string email)
    {
        // Business validation
        if (string.IsNullOrEmpty(email))
            throw new ArgumentException("Email required");
            
        var user = new User { Name = name, Email = email };
        _repository.Save(user);
        return user;
    }
}

// API Concern
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserRequest request)
    {
        var user = _userService.CreateUser(request.Name, request.Email);
        return Ok(user);
    }
}
```

## Layers vs Tiers

### Layers (Logical Separation)
- **Presentation Layer**: UI components
- **Business Layer**: Business logic and rules
- **Data Layer**: Data access and storage

### Tiers (Physical Separation)
- **Client Tier**: Web browser, mobile app
- **Application Tier**: Web server, API server
- **Database Tier**: Database server

## Benefits

- **Maintainability**: Easier to modify specific concerns
- **Testability**: Each concern can be tested independently
- **Reusability**: Concerns can be reused across different contexts
- **Scalability**: Different concerns can be scaled independently
- **Team Collaboration**: Different teams can work on different concerns