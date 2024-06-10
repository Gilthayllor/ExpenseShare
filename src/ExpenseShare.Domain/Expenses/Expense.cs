using ExpenseShare.Domain.Abstractions;
using ExpenseShare.Domain.Rooms;

namespace ExpenseShare.Domain.Expenses
{
    public sealed class Expense : Entity
    {
        public Name Name { get; private set; }

        public Money ExpenseValue { get; private set; }

        public Guid RoomId { get; private set; }
        public Room Room { get; init; }

        private readonly List<ExpenseParticipant> _expenseParticipants = [];
        public IReadOnlyCollection<ExpenseParticipant> ExpenseParticipants => _expenseParticipants;

        public Expense(Name name, Money expenseValue, Guid roomId)
        {
            Name = name;
            ExpenseValue = expenseValue;
            RoomId = roomId;
        }

        private static Expense Create(Name name, Money expenseValue, Guid roomId)
        {
            
        }
    }
}
