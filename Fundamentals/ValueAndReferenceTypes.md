# Value Types and Reference Types

## Value Types 
- Inherit from System.ValueType
- Passed by copy
- Value copied on assignment
- Sealed - other types cannot inherit from value types. 
- Stored on stack

## Reference Types
- Inherit from System.Object
- Passed by reference
- Only reference is copied on assignment
- Stored on the heap

## Code Examples

### Value Types Example
```csharp
int a = 10;
int b = a;  // Copy of value
a = 20;

Console.WriteLine(a); // 20
Console.WriteLine(b); // 10 (unchanged)
```

### Reference Types Example
```csharp
List<int> list1 = new List<int> { 1, 2, 3 };
List<int> list2 = list1;  // Copy of reference
list1.Add(4);

Console.WriteLine(list1.Count); // 4
Console.WriteLine(list2.Count); // 4 (same object)
```

## Common Types

### Value Types
- int, double, bool, char
- DateTime, decimal
- struct, enum

### Reference Types
- string, object
- List<T>, Array
- class, interface, delegate

## Memory Allocation Diagram

```
┌─────────────────┐    ┌─────────────────┐
│      STACK      │    │      HEAP       │
├─────────────────┤    ├─────────────────┤
│                 │    │                 │
│ Value Types:    │    │ Reference Types:│
│ ┌─────────────┐ │    │ ┌─────────────┐ │
│ │ int a = 10  │ │    │ │ List<int>   │ │
│ │ bool flag   │ │    │ │ {1,2,3}     │ │
│ │ char c      │ │    │ │             │ │
│ └─────────────┘ │    │ └─────────────┘ │
│                 │    │ ┌─────────────┐ │
│ References:     │    │ │ string      │ │
│ ┌─────────────┐ │    │ │ "Hello"     │ │
│ │ list1   ────┼─┼────┼→│             │ │
│ │ list2   ────┼─┼────┼→│             │ │
│ └─────────────┘ │    │ └─────────────┘ │
│                 │    │                 │
└─────────────────┘    └─────────────────┘
```

**Garbage collector** only cleans reference types

**Key Points:**
- **Value Types**: Stored directly on stack
- **Reference Types**: Reference on stack → Object on heap
- **Multiple References**: Can point to same heap object


