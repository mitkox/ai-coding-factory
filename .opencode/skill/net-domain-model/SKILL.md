---
name: net-domain-model
description: Create domain models following Domain-Driven Design principles
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  framework: entityframeworkcore
  patterns: ddd
---

## What I Do

I help you create domain models following DDD principles:
- Entities with identity
- Value objects (immutable)
- Aggregates and aggregate roots
- Domain events
- Repositories interfaces
- Domain services

## When to Use Me

Use this skill when:
- Modeling business domain
- Creating entity classes
- Implementing value objects
- Defining aggregate boundaries
- Creating domain services

## Domain Model Structure

```
src/{ProjectName}.Domain/
├── Entities/
│   ├── Product.cs
│   ├── Order.cs
│   └── Customer.cs
├── ValueObjects/
│   ├── Money.cs
│   ├── Email.cs
│   └── Address.cs
├── Aggregates/
│   └── OrderAggregate/
│       ├── Order.cs
│       └── OrderItem.cs
├── Interfaces/
│   ├── IProductRepository.cs
│   ├── IOrderRepository.cs
│   └── IUnitOfWork.cs
├── Events/
│   ├── OrderCreatedEvent.cs
│   └── OrderPaidEvent.cs
└── Services/
    └── DomainService.cs
```

## Patterns I Implement

### Entity
```csharp
public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public List<IDomainEvent> DomainEvents { get; } = new();

    protected Entity(Guid id) => Id = id;
    protected Entity() { }
}
```

### Value Object
```csharp
public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public bool Equals(ValueObject? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }
}
```

### Aggregate Root
```csharp
public abstract class AggregateRoot : Entity
{
    public override void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => DomainEvents.Clear();
}
```

## Best Practices

1. Entities protect invariants
2. Value objects are immutable
3. Aggregates define consistency boundaries
4. Domain events capture business events
5. Repositories are in Domain layer
6. Domain services contain business logic

## Example Usage

```
Create a domain model for an e-commerce system with:
- Product entity
- Order aggregate root
- Money value object
- OrderCreated domain event
- Repository interfaces
```

I will generate complete domain model following DDD patterns.