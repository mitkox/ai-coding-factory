---
name: net-repository-pattern
description: Implement repository pattern with Unit of Work for EF Core
license: MIT
compatibility: opencode
metadata:
  audience: .net-developers
  framework: entityframeworkcore
  patterns: repository
---

## What I Do

I implement repository pattern with Unit of Work:
- Generic repository base
- Specific repositories
- Unit of Work pattern
- EF Core integration
- Specification pattern support

## When to Use Me

Use this skill when:
- Implementing data access layer
- Adding repository abstractions
- Working with EF Core
- Need Unit of Work pattern

## Repository Structure

```
src/{ProjectName}.Infrastructure/Data/
├── DbContext/
│   ├── AppDbContext.cs
│   └── ApplicationDbContextFactory.cs
├── Repositories/
│   ├── Base/
│   │   ├── Repository.cs
│   │   └── ReadOnlyRepository.cs
│   ├── ProductRepository.cs
│   ├── OrderRepository.cs
│   └── UserRepository.cs
├── UnitOfWork/
│   ├── IUnitOfWork.cs
│   └── UnitOfWork.cs
├── Specifications/
│   ├── ISpecification.cs
│   └── SpecificationEvaluator.cs
└── Migrations/
```

## Repository Implementation

### Generic Repository Interface
```csharp
public interface IRepository<TEntity> 
    where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<IReadOnlyList<TEntity>> ListAsync(
        ISpecification<TEntity> spec);
    Task<TEntity?> GetEntityWithSpec(ISpecification<TEntity> spec);
    Task<int> CountAsync(ISpecification<TEntity> spec);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
```

### Unit of Work
```csharp
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    IUserRepository Users { get; }
    Task<int> CompleteAsync();
    Task RollbackAsync();
}
```

### Specification Pattern
```csharp
public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    string IncludeString { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
}
```

## Best Practices

1. Repositories are per aggregate root
2. Use specifications for complex queries
3. Unit of Work manages transactions
4. DbContext is internal to infrastructure
5. Repository interfaces in Domain layer
6. Implementations in Infrastructure layer

## Example Usage

```
Create repository implementation for:
- Product aggregate
- Order aggregate
- Customer aggregate
With Unit of Work pattern
```

I will generate complete repository implementation with EF Core.