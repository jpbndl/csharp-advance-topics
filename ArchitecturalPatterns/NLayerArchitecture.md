# N-Layer Architecture

A software architecture pattern that separates an application into distinct layers, each with specific responsibilities. This promotes separation of concerns, maintainability, and testability.

## Core Layers

### 1. Presentation Layer (UI)
- **Responsibility**: User interaction and data presentation
- **Contains**: Controllers, Views, Web APIs, Console interfaces
- **Dependencies**: Only depends on Business Layer

### 2. Business Layer (BLL)
- **Responsibility**: Business logic, validation, and processing
- **Contains**: Services, business rules, workflowssss
- **Dependencies**: Depends on Data Access Layer

### 3. Data Access Layer (DAL)
- **Responsibility**: Database operations and data persistence
- **Contains**: Repositories, data models, database context
- **Dependencies**: Only depends on database/external data sources

## Architecture Diagram

```
┌─────────────────────┐
│  Presentation Layer │ ← User Interface
│   (Controllers)     │
└──────────┬──────────┘
           │
           ▼
┌─────────────────────┐
│   Business Layer    │ ← Business Logic
│    (Services)       │
└──────────┬──────────┘
           │
           ▼
┌─────────────────────┐
│ Data Access Layer   │ ← Data Operations
│   (Repositories)    │
└──────────┬──────────┘
           │
           ▼
┌─────────────────────┐
│     Database        │
└─────────────────────┘
```

## Real-World Example: E-commerce System

### Data Models
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
}
```

### Data Access Layer
```csharp
public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task<Product> CreateAsync(Product product);
    Task UpdateStockAsync(int productId, int quantity);
}

public class ProductRepository : IProductRepository
{
    private readonly DbContext _context;
    
    public ProductRepository(DbContext context)
    {
        _context = context;
    }
    
    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }
    
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
    
    public async Task UpdateStockAsync(int productId, int quantity)
    {
        var product = await GetByIdAsync(productId);
        product.Stock -= quantity;
        await _context.SaveChangesAsync();
    }
}
```

### Business Layer
```csharp
public interface IOrderService
{
    Task<Order> CreateOrderAsync(int customerId, List<OrderItem> items);
    Task<bool> ValidateOrderAsync(List<OrderItem> items);
}

public class OrderService : IOrderService
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }
    
    public async Task<Order> CreateOrderAsync(int customerId, List<OrderItem> items)
    {
        // Business logic: Validate order
        if (!await ValidateOrderAsync(items))
            throw new InvalidOperationException("Invalid order");
        
        // Business logic: Calculate total
        decimal total = 0;
        foreach (var item in items)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            total += product.Price * item.Quantity;
            
            // Update stock
            await _productRepository.UpdateStockAsync(item.ProductId, item.Quantity);
        }
        
        var order = new Order
        {
            CustomerId = customerId,
            Items = items,
            Total = total,
            OrderDate = DateTime.Now
        };
        
        return await _orderRepository.CreateAsync(order);
    }
    
    public async Task<bool> ValidateOrderAsync(List<OrderItem> items)
    {
        foreach (var item in items)
        {
            var product = await _productRepository.GetByIdAsync(item.ProductId);
            if (product == null || product.Stock < item.Quantity)
                return false;
        }
        return true;
    }
}
```

### Presentation Layer
```csharp
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        try
        {
            var order = await _orderService.CreateOrderAsync(request.CustomerId, request.Items);
            return Ok(order);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
```

## Benefits

- **Separation of Concerns**: Each layer has a single responsibility
- **Maintainability**: Changes in one layer don't affect others
- **Testability**: Easy to unit test each layer independently
- **Reusability**: Business logic can be reused across different UIs
- **Scalability**: Layers can be scaled independently

## Best Practices

- **Dependency Direction**: Higher layers depend on lower layers, never the reverse
- **Use Interfaces**: Define contracts between layers using interfaces
- **Dependency Injection**: Use DI to manage dependencies between layers
- **Keep Layers Thin**: Avoid putting too much logic in any single layer
- **Data Transfer Objects**: Use DTOs to transfer data between layers

## Common Variations

- **4-Layer**: Add a separate Domain/Entity layer
- **5-Layer**: Include a separate Infrastructure layer
- **Onion Architecture**: Invert dependencies using interfaces
- **Clean Architecture**: Focus on dependency inversion and testability