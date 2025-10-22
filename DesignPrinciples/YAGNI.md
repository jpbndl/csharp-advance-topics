# YAGNI (You Aren't Gonna Need It)

A principle that states you should not add functionality until it is actually needed, not when you just foresee that you might need it.

## Core Concept

- **Build only what's required**: Implement features when they're actually needed
- **Avoid speculation**: Don't code for hypothetical future requirements
- **Focus on current needs**: Solve today's problems, not tomorrow's maybes
- **Reduce waste**: Unused code is wasted effort and maintenance burden

## Examples

### BAD - Building for future "what-ifs"
```csharp
// Over-engineered user system for simple blog
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
    // Not needed yet, but "might be useful"
    public string Phone { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public int LoginAttempts { get; set; }
    public bool IsLocked { get; set; }
    public string PreferredLanguage { get; set; }
    public string TimeZone { get; set; }
    public decimal AccountBalance { get; set; }
    public List<Permission> Permissions { get; set; }
}

public class UserService
{
    // Current requirement: just create users
    public User CreateUser(string name, string email)
    {
        return new User { Name = name, Email = email };
    }
    
    // "Future-proofing" methods not currently needed
    public void LockUser(int userId) { /* Complex locking logic */ }
    public void UnlockUser(int userId) { /* Complex unlocking logic */ }
    public void UpdateLoginAttempts(int userId) { /* Tracking logic */ }
    public void SetPreferences(int userId, string language, string timezone) { /* Preference logic */ }
    public decimal GetAccountBalance(int userId) { /* Balance logic */ }
}
```

### GOOD - Build only what's needed now
```csharp
// Simple user system for current blog requirements
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UserService
{
    // Only implemenst what's actually required
    public User CreateUser(string name, string email)
    {
        return new User { Name = name, Email = email };
    }
    a
    public User GetUser(int id)
    {
        // Simple retrieval logic
        return _repository.GetById(id);
    }
}
```

### BAD - Complex configuration system
```csharp
// Building flexible configuration system "just in case"
public interface IConfigurationProvider
{
    T GetValue<T>(string key);
    void SetValue<T>(string key, T value);
}

public class DatabaseConfigurationProvider : IConfigurationProvider
{
    // Complex database-backed configuration
}

public class FileConfigurationProvider : IConfigurationProvider
{
    // Complex file-based configuration
}

public class ConfigurationManager
{
    private readonly List<IConfigurationProvider> _providers;
    
    // Complex priority system, caching, etc.
    public T GetValue<T>(string key)
    {
        // Complex lookup logic across multiple providers
    }
}
```

### GOOD - Simple configuration
```csharp
// Simple configuration for current needs
public class AppSettings
{
    public string DatabaseConnectionString { get; set; }
    public string ApiKey { get; set; }
}

// Use built-in .NET configuration
public class UserService
{
    private readonly AppSettings _settings;
    
    public UserService(IOptions<AppSettings> settings)
    {
        _settings = settings.Value;
    }
}
```

### BAD - Generic repository pattern
```csharp
// Complex generic repository "for future flexibility"
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<int> CountAsync();
    Task<bool> ExistsAsync(int id);
}

public class GenericRepository<T> : IRepository<T> where T : class
{
    // Complex generic implementation with caching, logging, etc.
}
```

### GOOD - Specific repository for current needs
```csharp
// Simple repository for actual requirements
public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
}

public class UserRepository : IUserRepository
{
    private readonly DbContext _context;
    
    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    
    public async Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
```

## When to Apply YAGNI

- **Requirements gathering**: Only implement specified requirements
- **Feature requests**: Ask "Do we need this now or later?"
- **Code reviews**: Question unused or speculative code
- **Refactoring**: Remove code that's no longer needed
- **Architecture decisions**: Choose simple solutions over flexible ones

## Benefits

- **Faster delivery**: Less code to write and test
- **Reduced complexity**: Simpler codebase is easier to maintain
- **Lower costs**: Less development time and maintenance overhead
- **Better focus**: Team concentrates on actual business value
- **Easier changes**: Simpler code is easier to modify when requirements change

## Common Violations

- Adding "flexible" configuration systems before they're needed
- Building generic solutions for specific problems
- Implementing features "because we might need them later"
- Over-abstracting simple operations
- Adding extensive logging/monitoring before performance issues arise

## YAGNI vs Other Principles

- **YAGNI vs DRY**: Don't create abstractions until you have actual duplication
- **YAGNI vs SOLID**: Apply SOLID when you actually need the flexibility
- **YAGNI vs Design Patterns**: Use patterns to solve real problems, not potential ones

## Red Flags

- Code comments saying "for future use"
- Unused methods or properties
- Complex abstractions with single implementations
- Features requested "just in case"
- Extensive configuration options that aren't used