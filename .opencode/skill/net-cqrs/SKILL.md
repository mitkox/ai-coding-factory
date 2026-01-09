---
name: net-cqrs
description: Implement CQRS pattern with MediatR for .NET applications
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  framework: aspnetcore
  patterns: cqrs, mediator, event-sourcing
---

## What I Do

I help you implement CQRS (Command Query Responsibility Segregation):
- Command handlers for mutations
- Query handlers for reads
- MediatR pipeline configuration
- Validation with FluentValidation
- Domain events publishing
- Event sourcing basics

## When to Use Me

Use this skill when:
- Implementing CQRS architecture
- Setting up MediatR in a Clean Architecture project
- Creating command and query handlers
- Separating read and write models
- Publishing domain events

## Packages Required

```xml
<PackageReference Include="MediatR" Version="12.2.0" />
<PackageReference Include="FluentValidation" Version="11.9.0" />
<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="11.9.0" />
```

## Command Structure

### Base Command
```csharp
using MediatR;

public interface ICommand<out TResult> : IRequest<TResult>
{
}

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}
```

### Command Example
```csharp
public record CreateOrderCommand(
    Guid CustomerId,
    List<OrderItemDto> Items,
    string ShippingAddress
) : ICommand<OrderDto>;

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IPublisher _publisher;

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository,
        IMapper mapper,
        IPublisher publisher)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _publisher = publisher;
    }

    public async Task<OrderDto> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var order = Order.Create(
            request.CustomerId,
            request.Items.Select(i => new OrderItem(i.ProductId, i.Quantity, i.Price)),
            request.ShippingAddress);

        await _orderRepository.AddAsync(order, cancellationToken);

        // Publish domain events
        foreach (var domainEvent in order.DomainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }

        order.ClearDomainEvents();

        return _mapper.Map<OrderDto>(order);
    }
}
```

### Command Validator
```csharp
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage("Customer ID is required");

        RuleFor(x => x.Items)
            .NotEmpty()
            .WithMessage("At least one item is required");

        RuleForEach(x => x.Items)
            .ChildRules(item =>
            {
                item.RuleFor(x => x.Quantity)
                    .GreaterThan(0)
                    .WithMessage("Quantity must be greater than 0");

                item.RuleFor(x => x.Price)
                    .GreaterThan(0)
                    .WithMessage("Price must be greater than 0");
            });

        RuleFor(x => x.ShippingAddress)
            .NotEmpty()
            .MaximumLength(500)
            .WithMessage("Shipping address is required (max 500 characters)");
    }
}
```

## Query Structure

### Base Query
```csharp
using MediatR;

public interface IQuery<out TResult> : IRequest<TResult>
{
}

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}
```

### Query Example
```csharp
public record GetOrderByIdQuery(Guid OrderId) : IQuery<OrderDto?>;

public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly IOrderReadRepository _orderReadRepository;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(
        IOrderReadRepository orderReadRepository,
        IMapper mapper)
    {
        _orderReadRepository = orderReadRepository;
        _mapper = mapper;
    }

    public async Task<OrderDto?> Handle(
        GetOrderByIdQuery request,
        CancellationToken cancellationToken)
    {
        var order = await _orderReadRepository.GetByIdAsync(
            request.OrderId, 
            cancellationToken);

        return order is null ? null : _mapper.Map<OrderDto>(order);
    }
}
```

### Paginated Query
```csharp
public record GetOrdersQuery(
    Guid? CustomerId,
    DateTime? FromDate,
    DateTime? ToDate,
    int Page = 1,
    int PageSize = 10
) : IQuery<PaginatedList<OrderSummaryDto>>;

public class GetOrdersQueryHandler : IQueryHandler<GetOrdersQuery, PaginatedList<OrderSummaryDto>>
{
    private readonly IOrderReadRepository _repository;

    public GetOrdersQueryHandler(IOrderReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginatedList<OrderSummaryDto>> Handle(
        GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetPaginatedAsync(
            request.CustomerId,
            request.FromDate,
            request.ToDate,
            request.Page,
            request.PageSize,
            cancellationToken);
    }
}
```

## Pipeline Behaviors

### Validation Behavior
```csharp
public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (failures.Count != 0)
            throw new ValidationException(failures);

        return await next();
    }
}
```

### Transaction Behavior
```csharp
public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;

    public TransactionBehaviour(
        IUnitOfWork unitOfWork,
        ILogger<TransactionBehaviour<TRequest, TResponse>> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var typeName = typeof(TRequest).Name;

        try
        {
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            _logger.LogInformation("Begin transaction for {CommandName}", typeName);

            var response = await next();

            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            _logger.LogInformation("Committed transaction for {CommandName}", typeName);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during transaction for {CommandName}", typeName);

            await _unitOfWork.RollbackTransactionAsync(cancellationToken);

            throw;
        }
    }
}
```

## Domain Events

### Domain Event Handler
```csharp
public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly IEmailService _emailService;
    private readonly ILogger<OrderCreatedEventHandler> _logger;

    public OrderCreatedEventHandler(
        IEmailService emailService,
        ILogger<OrderCreatedEventHandler> logger)
    {
        _emailService = emailService;
        _logger = logger;
    }

    public async Task Handle(
        OrderCreatedEvent notification,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Processing OrderCreatedEvent for Order {OrderId}",
            notification.OrderId);

        await _emailService.SendOrderConfirmationAsync(
            notification.OrderId,
            notification.CustomerEmail,
            cancellationToken);
    }
}
```

## DI Registration

```csharp
services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

    // Add behaviors in order of execution
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));
});

services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
```

## Best Practices

1. **Separate Commands and Queries**: Keep read and write models separate
2. **Immutable Commands/Queries**: Use records for immutability
3. **Validation in Pipeline**: Use FluentValidation behaviors
4. **Transaction Management**: Wrap commands in transactions
5. **Event Publishing**: Publish domain events after successful commands
6. **Thin Handlers**: Keep handlers focused on orchestration

## Example Usage

```
Use net-cqrs skill to:

1. Create command with handler and validator
2. Create query with pagination support
3. Set up MediatR pipeline behaviors
4. Implement domain event handlers
5. Configure transaction behavior for commands
```

I will generate complete CQRS implementation following Clean Architecture principles.
