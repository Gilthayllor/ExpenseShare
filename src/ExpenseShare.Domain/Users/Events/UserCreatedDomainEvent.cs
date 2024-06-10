using ExpenseShare.Domain.Abstractions;

namespace ExpenseShare.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}
