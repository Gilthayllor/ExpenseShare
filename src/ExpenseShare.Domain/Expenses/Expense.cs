using ExpenseShare.Domain.Abstractions;
using ExpenseShare.Domain.Expenses.Events;
using ExpenseShare.Domain.Rooms;

namespace ExpenseShare.Domain.Expenses
{
    public sealed class Expense : Entity
    {
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public Money ExpenseValue { get; private set; }
        public Guid RoomId { get; private set; }
        public Room Room { get; private set; }

        private readonly List<ExpenseParticipant> _expenseParticipants = [];
        public IReadOnlyCollection<ExpenseParticipant> ExpenseParticipants => _expenseParticipants;

        private Expense(Name name, Money expenseValue, Guid roomId)
        {
            Name = name;
            ExpenseValue = expenseValue;
            RoomId = roomId;
        }

        private static Expense Create(Name name, Money expenseValue, Guid roomId)
        {
            var expense = new Expense(name, expenseValue, roomId);

            expense.RaiseDomainEvent(new ExpenseCreatedDomainEvent(expense.Id));

            return expense;
        }

        public void AddExpenseParticipant(ExpenseParticipant expenseParticipant)
        {
            _expenseParticipants.Add(expenseParticipant);

            RaiseDomainEvent(new ExpenseParticipantAddedDomainEvent(expenseParticipant.UserId, Id));
        }

        public void RemoveExpenseParticipant(ExpenseParticipant expenseParticipant)
        {
            _expenseParticipants.Remove(expenseParticipant);

            RaiseDomainEvent(new ExpensePartipantRemovedDomainEvent(expenseParticipant.UserId, Id));
        }
    }
}
