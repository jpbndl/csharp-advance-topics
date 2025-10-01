# Dynamic

The `dynamic` keyword in C# is used to declare a variable whose type is resolved at runtime rather than at compile time. 
This allows for more flexible and dynamic programming, as you can work with objects without knowing their types in advance.

## Progamming Lanugages 

Programming languages are diveded into two types:

### Statically Typed Languages: C#, Go, Java
- In statically typed languages, variable types are known at compile time.

### Dynamically Typed Languages: Ruby, Javacript, Python
- In dynamically typed languages, variable types are known at runtime.
- Easier and faster to write code. But more prone to runtime errors.

### C# History
- Started as a static language
- .NET 4 added the dynamic capability, to improve interoperability with 
	- COM objects
	- Dynamice languages (IronPython, IronRuby)


## Common Lafnguage Runtime (CLR) vs Dynamic Language Runtime (DLR)

### CLR
- CLR: Common Lafnguage Runtime
- CLR is .NET's virtual machine that gets your compiled code which is in **Intermediate Language (IL)** and converts that IL into machine code at runtime

### DLR
- In .NET 4, Microsoft introduced the Dynamic Language Runtime (DLR) on top of the CLR an gieve dynamic capabilities to C# and VB.NET