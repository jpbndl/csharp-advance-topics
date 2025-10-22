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
**Integral Types:**
- byte, sbyte
- short, ushort
- int, uint
- long, ulong

**Floating-Point Types:**
- float
- double
- decimal

**Other Built-in Types:**
- bool
- char
- DateTime, TimeSpan
- Guid

**User-Defined Types:**
- struct
- enum
- Nullable<T> (e.g., int?, bool?)

### Reference Types
**Built-in Types:**
- string
- object
- dynamic

**Arrays:**
- int[], string[], T[]
- Multidimensional arrays (int[,])
- Jagged arrays (int[][])

**Collections:**
- List<T>, Dictionary<TKey, TValue>
- Array, ArrayList
- Queue<T>, Stack<T>
- HashSet<T>, LinkedList<T>

**User-Defined Types:**
- class
- interface
- delegate
- record (C# 9+)

**Special Types:**
- Func<T>, Action<T>
- Task<T>, Task
- Exception and derived types

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


