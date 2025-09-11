# Delegates

- An object that knows how to call a method (or a group of methods).
- A reference to a function

## Why use delegates?

- For designing extensible and flexible applications (e.g., frameworks).

## .NET built-in delegates

- `Func<>`: Represents a method that returns a value and can take parameters.
- `Action<>`: Represents a method that does not return a value but can take parameters.

## Interface or Delegate?

Use a delegate when:

- An eventing design pattern is used.
- The caller does not need to access other properties or methods on the object implementing the method.