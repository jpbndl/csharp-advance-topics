# Errors

Types of errors: 
- **Complilation errors** - also known as synyax errors, reported by the compiler
- **Runtime errors** - thrown during program execution
- **Logical errors** - occur when programming works without crashing but does not produce the expected result

# Exceptions

- **System errors** - OutOfMemoryException
- **Parsing errors** - FormatException
- **Numeric errors** - OverflowException

## How to handle exceptions

```csharp
try {
    return 1 / 0;
} catch (DivideByZeroException e) {
    // catch should be done if an exception of a given type is thrown
    // handle exception when dividing by 0
} finally {
    // always executed
}
```


```csharp
try {

} catch (Exception e) {
    // handle all exceptions
    // not specific and may be hard to know the exact error
}
```

```csharp
try {

} catch (DivideByZeroException e) {
    // handle exception when dividing by 0
} catch (Exception e) {
    // handle all exceptions
    // not specific and may be hard to know the exact error
}
```

**Note:** Writing multiple catch blocks should be from the most specific to the most generic since exceptions will be caught by the first matching catch block.
