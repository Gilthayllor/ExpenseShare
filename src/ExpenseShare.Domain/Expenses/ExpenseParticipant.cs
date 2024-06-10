namespace ExpenseShare.Domain.Expenses
{
    public sealed class ExpenseParticipant
    {
        public Guid UserId { get; init; }
        public Guid ExpenseId { get; init; }
        public Money AmountOwed { get; init; } = Money.Zero();
        public Money AmountPaid { get; init; } = Money.Zero();

        public ExpenseParticipant(Guid userId, Guid expenseId, Money amountOwed, Money amountPaid)
        {
            UserId = userId;
            ExpenseId = expenseId;
            AmountOwed = amountOwed;
            AmountPaid = amountPaid;
        }
    }
}
