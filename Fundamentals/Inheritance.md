# Inheritance

## Does C# support multiple inheritance?

# ❌ NO!

C# does **NOT** support multiple class inheritance.

## ✅ BUT...

C# **DOES** support multiple interface implementation.

### What C# Allows

```csharp
// ✅ Single class inheritance
public class Animal { }
public class Dog : Animal { }  // OK

// ✅ Multiple interface implementation
public interface IFlyable { void Fly(); }
public interface ISwimmable { void Swim(); }

public class Duck : Animal, IFlyable, ISwimmable  // OK
{
    public void Fly() { Console.WriteLine("Flying"); }
    public void Swim() { Console.WriteLine("Swimming"); }
}
```

### What C# Does NOT Allow

```csharp
// ❌ Multiple class inheritance - COMPILATION ERROR
public class Vehicle { }
public class Boat { }
public class AmphibiousVehicle : Vehicle, Boat { }  // ERROR!
```

**Why No Multiple Inheritance?**
- Avoids the "Diamond Problem" (ambiguity when multiple base classes have same method)
- Keeps inheritance simple and predictable
- Interfaces provide the flexibility without the complexity

## The Diamond Problem Explained

### Visual Representation
```
        Animal
       /      \
   Mammal    Bird
       \      /
        Bat
```

### The Problem (Hypothetical C# Code)
```csharp
// If C# allowed multiple inheritance, this would be problematic:

public class Animal
{
    public virtual void Move()
    {
        Console.WriteLine("Animal moves");
    }
}

public class Mammal : Animal
{
    public override void Move()
    {
        Console.WriteLine("Mammal walks");
    }
}

public class Bird : Animal
{
    public override void Move()
    {
        Console.WriteLine("Bird flies");
    }
}

// This would cause ambiguity - WHICH Move() method should Bat inherit?
public class Bat : Mammal, Bird  // ERROR in C#!
{
    // Which Move() method does Bat get?
    // Mammal.Move() or Bird.Move()?
    // Compiler doesn't know!
}
```

### C#'s Solution: Interfaces
```csharp
public interface IMammal
{
    void Walk();
}

public interface IBird
{
    void Fly();
}

public class Bat : Animal, IMammal, IBird  // ✅ This works!
{
    public void Walk()
    {
        Console.WriteLine("Bat crawls");
    }
    
    public void Fly()
    {
        Console.WriteLine("Bat flies");
    }
}
```

**Diamond Problem Summary:**
- Multiple inheritance creates ambiguity when base classes have same methods
- C# avoids this by allowing only single class inheritance
- Interfaces solve the flexibility need without the ambiguity