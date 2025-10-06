# Garbage Collector

The Garbage Collector is responsible for managing the memory used by the application. **It frees the memory occupied by objects that are no longer used.**. Garbage collector is part of the CLR. *Please refer to CLR.md*

## Memory
C# objects are stored in the memory, stack or heap.

### Stack
- Stores value types and references to heap objects
- Fast allocation/deallocation
- Automatically managed (no GC needed)
- LIFO (Last In, First Out)

```csharp
void Method()
{
    int number = 42;        // Stored on stack
    bool flag = true;       // Stored on stack
    string name = "John";   // Reference on stack, object on heap
}  // Stack variables automatically cleaned up
```

### Heap
- Stores reference type objects
- Managed by Garbage Collector
- Slower allocation than stack
- Objects can live beyond method scope

```csharp
void CreateObjects()
{
    var list = new List<int>();     // Object created on heap
    var person = new Person();      // Object created on heap
}  // Objects remain on heap until GC collects them
```

## Garbage Collection Example

```csharp
class Person
{
    public string Name { get; set; }
    ~Person()  // Finalizer (called by GC)
    {
        Console.WriteLine($"{Name} is being collected");
    }
}

void Demo()
{
    var person1 = new Person { Name = "John" };
    var person2 = new Person { Name = "Jane" };
    
    person1 = null;  // No longer referenced
    person2 = null;  // No longer referenced
    
    GC.Collect();    // Force garbage collection
    GC.WaitForPendingFinalizers();
}

// Output:
// John is being collected
// Jane is being collected
```

## When GC Runs
- When heap memory is low
- When `GC.Collect()` is called (not recommended)
- At application shutdown
- Periodically by the runtime

**Note**: Objects become eligible for collection when no references point to them.

## Memory Fragmentation Example

### Before Defragmentation
```
HEAP MEMORY:
┌─────────┬─────────┬─────────┬─────────┬─────────┬─────────┐
│ String  │  FREE   │ Object  │  FREE   │ String  │  FREE   │
│ "Hello" │   10B   │  Data   │   15B   │ "World" │   20B   │
└─────────┴─────────┴─────────┴─────────┴─────────┴─────────┘

// Need to allocate 25B object - won't fit in any free space!
```

### After Defragmentation (GC Compaction)
```
HEAP MEMORY:
┌─────────┬─────────┬─────────┬─────────────────────────────┐
│ String  │ Object  │ String  │           FREE              │
│ "Hello" │  Data   │ "World" │            45B              │
└─────────┴─────────┴─────────┴─────────────────────────────┘

// Now 25B object can fit in the large free space!
```

## Memory Leak Example

```csharp
class MemoryLeakDemo
{
    private static List<string> _cache = new List<string>();
    
    public void ProcessData()
    {
        for (int i = 0; i < 1000000; i++)
        {
            string data = $"Data_{i}";
            _cache.Add(data);  // MEMORY LEAK! Never removed
        }
        // Method ends but _cache still holds references
        // Objects cannot be garbage collected!
    }
}

// Fix: Clear cache when done
public void ProcessDataFixed()
{
    var localCache = new List<string>();
    for (int i = 0; i < 1000000; i++)
    {
        localCache.Add($"Data_{i}");
    }
    // localCache goes out of scope - eligible for GC
}
```

## Memory States Diagram

```
MEMORY LEAK SCENARIO:
┌─────────────────────────────────────────────────────────────┐
│                    HEAP MEMORY                              │
├─────────────────────────────────────────────────────────────┤
│ Static Cache → [Obj1][Obj2][Obj3]...[Obj1000000]          │
│                     ↑                                       │
│              Never released!                                │
│              Memory keeps growing                           │
└─────────────────────────────────────────────────────────────┘

HEALTHY SCENARIO:
┌─────────────────────────────────────────────────────────────┐
│                    HEAP MEMORY                              │
├─────────────────────────────────────────────────────────────┤
│ [Active Objects]           [FREE SPACE]                    │
│                              ↑                             │
│                    Available for new objects               │
└─────────────────────────────────────────────────────────────┘
```