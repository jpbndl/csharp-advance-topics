# Ref and Out Keywords

## Ref
The `ref` keyword passes the value type to a method by reference.

### Example
```csharp
class Test {
    public static void Increment(int n) {
        ++n;
    }

    static void Main(string[] args) {
        var num = 1;
        Increment(num);

        Console.ReadLine($"num: {num}");
    }

    // Output:
    // 1
    // num will still be 1 because the function Increment creates a new copy of n
}
```

```csharp
class Test {
    public static void Increment(int n) {
        ++n;
    }

    static void Main(string[] args) {
        var num = 1;
        Increment(ref num);

        Console.ReadLine($"num: {num}");
    }

    // Output:
    // 2
    // Number is incremented. 
}
```

**The value passed by ref must be initialized before the method is called**

## Out
The `out` keyword allows us to return extra variables from a method

### Example
```csharp
class Calculator
{
    public static bool Divide(int a, int b, out int result)
    {
        if (b == 0)
        {
            result = 0;  // Must assign before returning
            return false;
        }
        
        result = a / b;
        return true;
    }
    
    static void Main()
    {
        int quotient;  // No need to initialize
        
        if (Divide(10, 2, out quotient))
        {
            Console.WriteLine($"Result: {quotient}");  // 5
        }
        else
        {
            Console.WriteLine("Division failed");
        }
    }
}
```

### Multiple Out Parameters
```csharp
public static void GetNameParts(string fullName, out string firstName, out string lastName)
{
    string[] parts = fullName.Split(' ');
    firstName = parts[0];
    lastName = parts.Length > 1 ? parts[1] : "";
}

// Usage
string first, last;
GetNameParts("John Doe", out first, out last);
Console.WriteLine($"First: {first}, Last: {last}");
```

### Out with TryParse
```csharp
string input = "123";
if (int.TryParse(input, out int number))
{
    Console.WriteLine($"Parsed: {number}");
}
else
{
    Console.WriteLine("Invalid number");
}
```

**Key Points:**
- `out` parameters don't need to be initialized before the method call
- The method **must** assign a value to all `out` parameters before returning
- `out` parameters are passed by reference

