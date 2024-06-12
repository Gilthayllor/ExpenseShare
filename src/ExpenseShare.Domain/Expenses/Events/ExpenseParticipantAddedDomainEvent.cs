using ExpenseShare.Domain.Abstractions;

namespace ExpenseShare.Domain.Expenses.Events
{
    public record ExpenseParticipantAddedDomainEvent(Guid UserId, Guid ExpenseId): IDomainEvent;
}
