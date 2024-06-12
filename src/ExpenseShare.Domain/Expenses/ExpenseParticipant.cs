namespace ExpenseShare.Domain.Expenses
{
    public sealed class ExpenseParticipant
    {
        public Guid UserId { get; init; }
        public Guid ExpenseId { get; init; }
        public Money AmountOwed { get; init; } = Money.Zero();
        public Money AmountPaid { get; private set; } = Money.Zero();
        public Money RemainingAmount => AmountOwed - AmountPaid;

        public ExpenseParticipant(Guid userId, Guid expenseId, Money amountOwed)
        {
            UserId = userId;
            ExpenseId = expenseId;
            AmountOwed = amountOwed;
        }

        public void Pay(Money money)
        {
            if (money == Money.Zero())
            {
                throw new ArgumentException("Amount must be greater than zero");
            }

            if (AmountOwed.Amount < money.Amount)
            {
                throw new ArgumentException("Amount paid cannot exceed amount owed");
            }

            var newAmountPaid = AmountPaid += money;
            if(newAmountPaid.Amount > AmountOwed.Amount)
            {
                throw new InvalidOperationException("Total amount paid cannot exceed amount owed");
            }
        }
        
    }
}
