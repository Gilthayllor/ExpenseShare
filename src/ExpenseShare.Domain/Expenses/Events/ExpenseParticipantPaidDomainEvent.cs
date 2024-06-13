using ExpenseShare.Domain.Abstractions;

namespace ExpenseShare.Domain.Expenses.Events
{
    public sealed record ExpenseParticipantPaidDomainEvent(Guid UserId, Guid ExpenseId, Money AmountPaid) : IDomainEvent;
}
