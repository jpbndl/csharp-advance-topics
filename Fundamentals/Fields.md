# Fields
A variable that we declare at the class level and we use that to store data about the class. 

## Initialization

### With constructor

```csharp
public class Person {
    List<Address> Addresses; 
    
    public Person() {
        Addresses = new List<Address>();
    }
}
```
### Without constructor
We can have multiple constructors and the Addresses field will always be initialized.

```csharp
public class Person {
    List<Address> Addresses = new List<Address>();; 
}
```

## Read-only Fields
`readonly` is a keyword that makes a field immutable after initialization . It can only be assigned during declaration or in the constructor.

```csharp
public class Person {
    public readonly List<Address> Addresses = new List<Address>();
}
```

## Naming Conventions

Common naming convention for field is **PascalCase**

- For **private** - naming usually starts with "_" and naming convention is **camelCase**
```csharp
public class Person {
    private DateTime _birthdate;
}

```
