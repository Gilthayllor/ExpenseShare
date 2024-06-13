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

        private Expense(Name name, Description description, Money expenseValue, Guid roomId)
        {
            Name = name;
            Description = description;
            ExpenseValue = expenseValue;
            RoomId = roomId;
        }

        private Expense() { }

        private static Expense Create(Name name, Description description, Money expenseValue, Guid roomId)
        {
            var expense = new Expense(name, description, expenseValue, roomId);

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

        public void PayParticipant(Guid userId, Money money)
        {
            var participant = _expenseParticipants.FirstOrDefault(p => p.UserId == userId);
            if (participant == null)
            {
                throw new ArgumentException("Participant not found for the given user id");
            }

            participant.Pay(money);

            RaiseDomainEvent(new ExpenseParticipantPaidDomainEvent(userId, Id, money));
        }
    }
}
