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

## Real-World Example: ArrayList vs List<int>

```csharp
// OLD WAY: ArrayList (causes boxing/unboxing)
ArrayList oldList = new ArrayList();
oldList.Add(10);    // Boxing: int → object
oldList.Add(20);    // Boxing: int → object
oldList.Add(30);    // Boxing: int → object

// Retrieving requires unboxing
int first = (int)oldList[0];  // Unboxing: object → int
int sum = 0;
foreach (object item in oldList)
{
    sum += (int)item;  // Unboxing on every iteration
}

// MODERN WAY: List<int> (no boxing/unboxing)
List<int> modernList = new List<int>();
modernList.Add(10);  // Direct storage, no boxing
modernList.Add(20);  // Direct storage, no boxing
modernList.Add(30);  // Direct storage, no boxing

// No casting needed
int firstModern = modernList[0];  // Direct access
int sumModern = modernList.Sum(); // No unboxing needed
```

## Performance Impact
- **ArrayList**: Every int gets boxed (heap allocation) + unboxed (casting)
- **List<int>**: Direct value type storage, no boxing overhead
- **Memory**: ArrayList uses ~3x more memory for integers
- **Speed**: List<int> is significantly faster for value types

## When Boxing Still Happens
```csharp
// Boxing still occurs when:
int value = 42;
Console.WriteLine(value);        // Boxing: int → object for WriteLine(object)
string.Format("{0}", value);    // Boxing: int → object for formatting

// Avoid with:
Console.WriteLine(value.ToString());  // No boxing
$"Value: {value}"                     // No boxing (string interpolation)
```