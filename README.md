# CSharpAdvanceTopics

A comprehensive C#/.NET project demonstrating advanced language features and programming concepts. This repository is designed for learners and developers who want to deepen their understanding of modern C# (targeting .NET 8 and .NET 9).

## Topics Covered

- **Generics**: Type-safe data structures and methods, including custom implementations like `GenericList<T>` and `GenericDictionary<TKey, TValue>`.
- **Delegates**: Encapsulating method references and enabling flexible callback patterns.
- **Lambda Expressions**: Concise syntax for defining anonymous functions and expressions.
- **Events**: Implementing the observer pattern and building event-driven applications.
- **Extension Methods**: Adding new methods to existing types without modifying their source code.
- **LINQ (Language Integrated Query)**: Querying collections and databases using expressive, type-safe syntax.
- **Nullable Types**: Working with value types that can represent null values, including custom and built-in nullable support.
- **Dynamic**: Using dynamic typing for scenarios where type information is not known at compile time.
- **Exception Handling**: Robust error handling using try/catch/finally, custom exceptions, and best practices.
- **Asynchronous Programming**: Writing responsive and scalable code using async/await, tasks, and parallelism.

## Project Structure

- `CSharpAdvanceTopics/` - Main library with all advanced C# topic implementations.
- `CSharpAdvanceTopics.Tests/` - Unit tests (using xUnit) for validating the behavior of each topic and feature.

## Getting Started

1. **Clone the repository**
2. Open the solution in Visual Studio 2022 or later (with .NET 8/9 SDK installed).
3. Build the solution to restore dependencies.
4. Explore the code in each topic folder (e.g., `Generics`, `Delegates`, `LINQ`).
5. Run the tests in `CSharpAdvanceTopics.Tests` to see examples and verify correctness.

## Example: Generics

```csharp
var users = new GenericList<User>();
users.Add(new User { Id = 1, Name = "JP" });
users.Add(new User { Id = 2, Name = "Sandi" });
Console.WriteLine(users.Count); // Output: 2
```

## Contributing

Contributions, suggestions, and improvements are welcome! Please open an issue or submit a pull request.