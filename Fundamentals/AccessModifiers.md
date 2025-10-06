# Access Modifiers

C# access modifiers:

- **public** - accessible by any other type (class,struct,etc) in **any** assembly
- **internal** - accessible by any other type from the **same** assembly
- **protected** - accessible in the **same** class or those who **inherits** from that class. (SampleClass : InheritedClass)
- **protected internal** 
    - it works as **internal** in the same assembly
    - it works as **protected** outside the assembly
- **private protected** 
    - it works as **protected** in the same assembly
    - cannot be access outside the assembly even when inheriting from the class.
- **private** - accessible in the **same** class only

*Access modifiers works for classes structs and records with the same effect*

## Types

- class
- records
- structs - do not support inheritance so we can only use the following access modifiers:

- **public**
- **internal**
- **private**

## Default access modifiers

Default access modifiers are the **most restrictive access** modifiers that are valid in the given context:
- **namespace** - classes, structs, records, enums, delegates, interfaces
    - class SampleClass = internal class SampleClass
- **class, record, struct** - fields, properties, methods, events
    - int number = private int number

## Sealed modifier

Sealed modifiers prevents a class from being inherited, or an overridden method from further overriding.

### Sealed Class Example
```csharp
public sealed class FinalClass
{
    public void DoSomething() { }
}

// This will NOT compile
public class ChildClass : FinalClass  // Error!
{
}
```

### Sealed Method Example
```csharp
public class BaseClass
{
    public virtual void Method() { }
}

public class MiddleClass : BaseClass
{
    public sealed override void Method()  // Sealed override
    {
        // Implementation
    }
}

public class DerivedClass : MiddleClass
{
    // This will NOT compile
    public override void Method() { }  // Error!
}
```