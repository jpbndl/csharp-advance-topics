# Boxing and Unboxing

**Boxing** is the process of wrapping a value type into an instance of type System.Object and on the other hand, **Unboxing** is the opposite where it converts the boxed value back to a value type.

## Example

```csharp
// Boxing - value type to object
int number = 42;        // Value type on stack
object boxed = number;  // Boxing - moved to heap

// Unboxing - object back to value type
int unboxed = (int)boxed;  // Unboxing - explicit cast required

Console.WriteLine(unboxed); // 42
```

## Performance Impact
- **Boxing**: Allocates memory on heap, slower
- **Unboxing**: Requires type checking and casting
- **Solution**: Use generics to avoid boxing

```csharp
// Avoid boxing with generics
List<int> numbers = new List<int>();  // No boxing
numbers.Add(42);  // Direct value type storage
```