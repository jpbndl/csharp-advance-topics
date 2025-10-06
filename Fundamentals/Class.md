# Class

## Classes
- Reference types
    - Inherit from System.Object
    - Passed by reference
    - Support inheritance
    - Stored on the heap
- Can have destructors/finalizers - called by garbage collector removes an object from memory
- No parameterless constructor unless explicitly defined
- Support polymorphism and virtual methods

### Partial class

Partial classes are clases that are split into multiple source files. All the partial classes will be combined during the compilation. Partial can also be implemented in structs, intefaces and methods.

```csharp
partial class Helpers {
    private void Log() {}
}

partial class Helpers {
    private void Notify() {}
}
```

### Partial Use Case
This can be used when the class is too large and too many developers are working on the same class.

## Static class

A static class is a class that cannot be instantiated and can only contain static methods and members. It can work as a container for static methods.

### Working Example
```csharp
public static class MathHelper
{
    public static int Add(int a, int b)
    {
        return a + b;
    }
    
    public static double Pi = 3.14159;
}

// Usage
int result = MathHelper.Add(5, 3);  // Works fine
double pi = MathHelper.Pi;          // Works fine
```

### Not Working Example
```csharp
public static class MathHelper
{
    public int instanceField;           // ERROR! Cannot have instance members
    
    public void InstanceMethod() { }    // ERROR! Cannot have instance methods
    
    public MathHelper() { }             // ERROR! Cannot have constructors
}

// Usage
var helper = new MathHelper();      // ERROR! Cannot instantiate static class
```

```csharp
public static class MathHelper
{
    static int _total;

    static MathHelper(int total) { // ERROR! Cannot have parameters
        _total = total; 
    }
}
```

```csharp
public static class MathHelper
{
    int _total;

    static MathHelper() { 
        _total = 0; // ERROR! A static constructor can only operate on static members of a class
    }
}
```

**Rules for Static Classes:**
- All members must be static
- Cannot be instantiated
- Cannot have constructors
- Cannot inherit from other classes
- Cannot be inherited
- We can't use `this` keyword because `this` refers to the current instance 

**Rules for constructor in a Static clas**
- It must be parameterless
- It cannot have access modifiers
- It cannot be inherited or overloaded
- It cannot be called directly

## `new` keyword

The `new` keyword is used in **operator**, **modifier**, and **constraint**

### Example
```csharp
public class SampleClass<T> where T : new() {
    private T _val;
    public T Get() {
        if (_val == null) {
            // without the constraint where T : new(), this will get an error since it does not 
            // know where T requires an argument
            _val = new T();
        }
        return _val;
    }
    public T Set() { }
}
```

## `static` keyword

The static keyword can be used to declare static **class (including its member)**, **structs** and **records**. In class, static members belongs to a class as a whole, not to an instance.

Static modifier can be applied to: 
- Fields, properties, methods, constructors, events, operators, and local functions

**Notes**
**You cannot have a static structs**
**A static method cannot refernce non-static members as it is not aware of the non-static fields.**

Static can be accessed by:
```csharp
public class Helper {
    public static int count; 
}
Helper.count // accessing via the class, not instance

using static System.Helper; // using a static directive
count
```

### Example
```csharp
public class Helper {
    public static int count;
}

var helperInstance = new Helper();
helperInstance.count; // This will produced an error as static members belong to a type itself not to a specific instance
Helper.count; // This is the correct way to access the static members
```

```csharp
public class Helper {
    public static int count;

    public int GetCount() {
        // This will work since count is part of the class Helper
        var c = count;
    }

    public static string readCount() {
        return $"Count: {count}";
    }
}
```

### What will be the output of the code below?
```csharp
class Counter {
    static int Value;

    public void IncrementValue() {
        Value++;
    }

    public int GetValue() {
        return Value;
    }
}
using static System.Console;

class Program {
    static void Main(string[] args) {
        var ctr1 = new Counter();
        ctr1.IncrementValue();
        ctr1.IncrementValue(); 

        var ctr2 = new Counter();
        ctr2.IncrementValue(); 

        Writeline($"ctr1 : {ctr1.GetValue()}");
        Writeline($"ctr2 : {ctr2.GetValue()}");
    }
}

// Output: 
// ctr1: 3
// ctr2: 3
// Static fields belong to the class itself, not individual instances, so all instances share the same Value variable. // Both ctr1 and ctr2 see the same value of 3
```
### Can GetItems be made static?

```csharp
class Helper {
    private List<Items> _items;
    public void GetItems() {
        Writeline($"items: {_items}")
    }
}

// Answer: No
// GetItems method uses the non-static _items field.
// Static methods belong to the class itself, not to any specific instance
// Instance fields (_items) belong to individual instances
// Static methods don't know which instance's _items to access
```

## Structs
- Value types
    - Inhertis from System.ValueType
    - Passed by copy
    - Are sealed
    - Stored on the stack
- Do not support inheritance but can implement interfaces
- Cannot have destructors
- Always have a parameterless constructor even if it is not defined explicitly

```csharp
public struct Point {
    public int x;
    public int y;

    // can be defined without this
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
// This will work without any errors
var point = new Point();
```

```csharp
public class Point {
    public int x;
    public int y;

    // can be defined without this
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

// This will cause an error as no arguments are supplied
var point = new Point();
```