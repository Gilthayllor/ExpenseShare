namespace ExpenseShare.Domain.Rooms
{
    public sealed record Code
    {
        public string Value { get; init; }

        private Code(string value)
        {
            Value = value;
        }

        public static Code FromValue(string value)
        {
            return new Code(value);
        }

        public static Code NewCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 6)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return new Code(result);
        }
    }
}
