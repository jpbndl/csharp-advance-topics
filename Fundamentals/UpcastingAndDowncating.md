# Upcasting and Downcasting

- **Upcasting** - Conversion from a derived class to a base class (always safe)
- **Downcasting** - Conversion from a base class to a derived class (needs checking)

## Real-World Example: Streaming Service

```csharp
public class Media
{
    public string Title { get; set; }
    public void Play() => Console.WriteLine($"Playing {Title}");
}

public class Movie : Media
{
    public string Director { get; set; }
    public void ShowCredits() => Console.WriteLine($"Directed by {Director}");
}

public class Song : Media
{
    public string Artist { get; set; }
    public void ShowLyrics() => Console.WriteLine($"♪ Lyrics for {Title} by {Artist} ♪");
}

// Usage Example
var movie = new Movie { Title = "Inception", Director = "Christopher Nolan" };
var song = new Song { Title = "Bohemian Rhapsody", Artist = "Queen" };

// Upcasting (safe) - treating specific types as general Media
Media[] playlist = { movie, song };

foreach (Media media in playlist)
{
    media.Play(); // Works for all Media types
    
    // Downcasting with 'is' pattern (safe)
    if (media is Movie m)
        m.ShowCredits();
    
    if (media is Song s)
        s.ShowLyrics();
}

// Downcasting with 'as' (safe)
Media someMedia = playlist[0];
Movie asMovie = someMedia as Movie;
if (asMovie != null)
    asMovie.ShowCredits();

// Direct cast (unsafe - can throw exception)
Movie directCast = (Movie)someMedia; // OK if someMedia is actually a Movie
```

## WPF Event Handler Example

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    // sender is upcast to object, we need to downcast to access Button properties
    
    // Safe downcasting with 'as'
    Button clickedButton = sender as Button;
    if (clickedButton != null)
    {
        clickedButton.Content = "Clicked!";
        clickedButton.IsEnabled = false;
    }
    
    // Or with 'is' pattern matching
    if (sender is Button btn)
    {
        btn.Background = Brushes.Green;
    }
}
```

## Key Points
- **Upcasting**: Automatic and safe (Movie → Media)
- **Downcasting**: Requires explicit casting and checking (Media → Movie)
- Use `is` for type checking with pattern matching
- Use `as` for safe casting that returns null if unsuccessful
- Direct casting `(Type)` throws exception if types don't match

