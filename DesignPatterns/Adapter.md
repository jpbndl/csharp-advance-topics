# Adapter

The Adapter is a design pattern that allows converting an interface of a class to the interface expected by a client.

## Example

```csharp
// Your application expects this interface
public interface IPaymentProcessor
{
    bool ProcessPayment(decimal amount, string cardNumber);
}

// Third-party library with different interface
public class StripePaymentGateway
{
    public string ChargeCard(string cardNum, double amountInCents)
    {
        Console.WriteLine($"Stripe: Charging {amountInCents} cents to card {cardNum}");
        return "success";
    }
}

// Adapter converts StripePaymentGateway to IPaymentProcessor
public class StripeAdapter : IPaymentProcessor
{
    private readonly StripePaymentGateway _stripeGateway;
    
    public StripeAdapter(StripePaymentGateway stripeGateway)
    {
        _stripeGateway = stripeGateway;
    }
    
    public bool ProcessPayment(decimal amount, string cardNumber)
    {
        // Convert decimal to cents (double)
        double amountInCents = (double)(amount * 100);
        
        // Call the third-party method
        string result = _stripeGateway.ChargeCard(cardNumber, amountInCents);
        
        // Convert result to expected format
        return result == "success";
    }
}

// Usage
var stripeGateway = new StripePaymentGateway();
IPaymentProcessor processor = new StripeAdapter(stripeGateway);

bool success = processor.ProcessPayment(25.99m, "1234-5678-9012-3456");
Console.WriteLine($"Payment successful: {success}");

// Output:
// Stripe: Charging 2599 cents to card 1234-5678-9012-3456
// Payment successful: True
```

## Key Points
- Adapter implements the expected interface (`IPaymentProcessor`)
- Wraps the incompatible class (`StripePaymentGateway`)
- Converts method calls and data formats
- Allows using third-party libraries without changing your code
- "Plugs" incompatible interfaces together