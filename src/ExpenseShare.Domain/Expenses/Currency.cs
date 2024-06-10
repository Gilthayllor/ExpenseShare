namespace ExpenseShare.Domain.Expenses
{
    public sealed record Currency
    {
        public static Currency BRL = new Currency("BRL");
        public static Currency None = new Currency(string.Empty);
        public string Code { get; init; }

        private Currency(string code)
        {
            Code = code;
        }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(x => x.Code == code) ?? throw new ApplicationException("Currency code invalid");
        }

        public static IReadOnlyCollection<Currency> All = [
            BRL
        ];
    }
}
