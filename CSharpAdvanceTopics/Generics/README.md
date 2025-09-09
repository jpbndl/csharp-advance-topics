# Generics in C#

This module demonstrates the use of generics in C# by implementing a simple generic list class.

## What are Generics?

Generics allow you to define classes, interfaces, and methods with a placeholder for the type of data they store or use. This enables you to create reusable and type-safe code that works with any data type.

## Benefits of Generics

- **Type Safety**: Compile-time type checking reduces runtime errors.
- **Code Reusability**: Write one class or method that works with any data type.
- **Performance**: Avoids boxing/unboxing for value types.
- **Maintainability**: Reduces code duplication and casting.

## Example: GenericList<T>

The `GenericList<T>` class is a simple, type-safe list implementation:

```csharp
public class GenericList<T>
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public int Count => _items.Count;

    public T this[int index] => _items[index];

    public bool Remove(T item)
    {
        return _items.Remove(item);
    }

    public void Clear()
    {
        _items.Clear();
    }
}
```

## Usage Example

Suppose you have a `User` class:

```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}
```

You can use `GenericList<User>` to store users:

```csharp
var users = new GenericList<User>();
users.Add(new User { Id = 1, Name = "JP" });
users.Add(new User { Id = 2, Name = "Sandi" });
users.Add(new User { Id = 3, Name = "Jaine" });

Console.WriteLine(users.Count);      // Output: 3
Console.WriteLine(users[0].Name);    // Output: JP
```

## Unit Testing

A sample test using xUnit:

```csharp
[Fact]
public void Add_ShouldCreateAListOfUsers()
{
    var users = new GenericList<User>();
    users.Add(new User { Id = 1, Name = "JP" });
    users.Add(new User { Id = 2, Name = "Sandi" });
    users.Add(new User { Id = 3, Name = "Jaine" });

    Assert.Equal(3, users.Count);
    Assert.Equal("JP", users[0].Name);
    Assert.Equal("Sandi", users[1].Name);
    Assert.Equal("Jaine", users[2].Name);
}
```

## Summary

Generics are a powerful feature in C# that enable you to write flexible, reusable, and type-safe code. The `GenericList<T>` class is a simple example of how generics can be used to create collections that work with any data type.
