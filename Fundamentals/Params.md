# params 

The "params" keyword allows us to pass any number of parameters of the **same type** to a method. Params keyword must be the **last** in the arguments. 

*We can only use params keyword in a single-dimensional array*

## Example

```csharp
public static int Sum(params int[] numbers)
{
    int total = 0;
    foreach (int num in numbers)
        total += num;
    return total;
}

// Usage - multiple ways to call
Sum(1, 2, 3);           // 6
Sum(10, 20, 30, 40);    // 100
Sum();                  // 0 (empty)
Sum(new int[] {5, 15}); // 20 (explicit array)
```

## With Other Parameters

```csharp
public static string Format(string template, params object[] values)
{
    return string.Format(template, values);
}

// Usage
Format("Hello {0}, you are {1} years old", "John", 25);
// Result: "Hello John, you are 25 years old"
```