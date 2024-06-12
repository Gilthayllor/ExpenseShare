using ExpenseShare.Domain.Abstractions;

namespace ExpenseShare.Domain.Expenses.Events
{
    public sealed record ExpenseCreatedDomainEvent(Guid ExpenseId): IDomainEvent;
}
