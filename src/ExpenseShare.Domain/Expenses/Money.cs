namespace ExpenseShare.Domain.Expenses
{
    public sealed record Money
    {
        public decimal Amount { get; init; }
        public Currency Currency { get; init; }

        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money Zero() => new Money(0, Currency.None);
        public static Money Zero(Currency currency) => new Money(0, currency);

        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Currencies have to be equal");

            return new Money(a.Amount + b.Amount, a.Currency);
        }
    }
}
