# Properties

A class member that encapsulates a getter/setter for accessing a field.

```csharp
public class Person {
    private DateTime _birthdate; 

    public void SetBirthdate(DateTime birthdate) {
        this._birthdate = birthdate;
    }

    public DateTime GetBirthdate() {
        return _birthdate;
    }
}
```

```csharp
public class Person {
    private DateTime _birthdate; 
    public DateTime Birthdate {
        get { return _birthdate; }
        set { _birthdate = value; }
    }
}
```

## Auto-implemented Properties
```csharp
public class Person {
    // C# complier internally creates a private field 
    pu
    public DateTime Birthdate { get; set; }
}
```

### Getter without setter
```csharp
public class Person {
    public DateTime Birthdate { get; set; }
    public int Age {
        get {
            var timeSpan = DateTime.Today - Birthdate;
            var years = timeSpan.Days / 365;

            return years
        }
    }
}
```

### Private setter
```csharp
public class Person {
    public DateTime Birthdate { get; private set; }
    
    public int Age {
        get {
            var timeSpan = DateTime.Today - Birthdate;
            var years = timeSpan.Days / 365;

            return years
        }
    }

    public Person(DateTime birthdate) {
        Birthdate = birthdate;
    }
}
```

## Indexers
A way to access elements in a class that represents a list of values. An indexer is nothing but a property.

## Example
```csharp
public class ExampleIndexer {
    var cookie = new HttpCookie();
    cookie.Expire = DateTime.Today.AddDays(5);

    var name = cookie["name"]; //Using Indexer
    var name = cookie.GetItem("name"); 
}

public class HttpCookie {
    // Instead of identifier, we use this keyword
    public string this[string key] { // Indexer notation [string key]
        get {}
        set {}
    }
}

public class HttpCookie {
    private readonly Dictionary<string, string> _dictionary;

    public HttpCoockie() {
        _dictionary = new Dictionary<string, string>();
    }

    public string this[string key] {
        get { return _dictionary[key] }
        set { _dictionary[key] = value; }
    }
}
```