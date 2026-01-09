using FluentAssertions;
using ProjectName.Domain.Common;
using Xunit;

namespace ProjectName.UnitTests.Domain;

[Trait("Story", "ACF-0001")]
public class EntityTests
{
    private sealed class TestEntity : Entity
    {
        public TestEntity() : base()
        {
        }

        public TestEntity(Guid id) : base(id)
        {
        }
    }

    private sealed class OtherEntity : Entity
    {
        public OtherEntity(Guid id) : base(id)
        {
        }
    }

    private sealed class TestAggregateRoot : AggregateRoot
    {
        public TestAggregateRoot() : base()
        {
        }

        public TestAggregateRoot(Guid id) : base(id)
        {
        }

        public void Touch() => IncrementVersion();
    }

    private sealed class TestDomainEvent : DomainEvent
    {
    }

    [Fact]
    public void EntityConstructorShouldSetIdAndCreatedAt()
    {
        // Act
        var entity = new TestEntity();

        // Assert
        entity.Id.Should().NotBe(Guid.Empty);
        entity.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void EntityEqualityShouldUseIdAndType()
    {
        // Arrange
        var id = Guid.NewGuid();
        var left = new TestEntity(id);
        var right = new TestEntity(id);
        var other = new OtherEntity(id);

        // Assert
        left.Equals(right).Should().BeTrue();
        (left == right).Should().BeTrue();
        (left != right).Should().BeFalse();
        left.Equals(other).Should().BeFalse();
        left.Equals(left).Should().BeTrue();
    }

    [Fact]
    public void EntityEqualityShouldReturnFalseForEmptyIds()
    {
        // Arrange
        var left = new TestEntity(Guid.Empty);
        var right = new TestEntity(Guid.Empty);

        // Assert
        left.Equals(right).Should().BeFalse();
    }

    [Fact]
    public void EntityEqualityShouldReturnFalseForDifferentTypes()
    {
        // Arrange
        var entity = new TestEntity();

        // Assert
        entity.Equals("not-an-entity").Should().BeFalse();
    }

    [Fact]
    public void EntityOperatorsShouldHandleNulls()
    {
        // Arrange
        TestEntity? left = null;
        TestEntity? right = null;

        // Assert
        (left == right).Should().BeTrue();
        (left != right).Should().BeFalse();
    }

    [Fact]
    public void EntityOperatorsShouldHandleOneNullOperand()
    {
        // Arrange
        TestEntity? left = null;
        var right = new TestEntity();

        // Assert
        (left == right).Should().BeFalse();
        (right == left).Should().BeFalse();
    }

    [Fact]
    public void EntityShouldManageDomainEvents()
    {
        // Arrange
        var entity = new TestEntity();
        var domainEvent = new TestDomainEvent();

        // Act
        entity.RaiseDomainEvent(domainEvent);
        entity.DomainEvents.Should().Contain(domainEvent);
        entity.RemoveDomainEvent(domainEvent);
        entity.DomainEvents.Should().BeEmpty();
        entity.RaiseDomainEvent(domainEvent);
        entity.ClearDomainEvents();

        // Assert
        entity.DomainEvents.Should().BeEmpty();
    }

    [Fact]
    public void EntityShouldSetAuditFields()
    {
        // Arrange
        var entity = new TestEntity();

        // Act
        entity.SetCreatedBy("user-1");
        entity.SetUpdatedBy("user-2");

        // Assert
        entity.CreatedBy.Should().Be("user-1");
        entity.UpdatedBy.Should().Be("user-2");
        entity.UpdatedAt.Should().NotBeNull();
    }

    [Fact]
    public void AggregateRootShouldIncrementVersion()
    {
        // Arrange
        var aggregate = new TestAggregateRoot();

        // Act
        aggregate.Touch();

        // Assert
        aggregate.Version.Should().Be(1);
    }

    [Fact]
    public void DomainEventShouldSetDefaults()
    {
        // Act
        var domainEvent = new TestDomainEvent();

        // Assert
        domainEvent.EventId.Should().NotBe(Guid.Empty);
        domainEvent.OccurredOn.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }
}
