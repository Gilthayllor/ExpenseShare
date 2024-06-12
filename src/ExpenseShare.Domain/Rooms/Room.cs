using ExpenseShare.Domain.Abstractions;
using ExpenseShare.Domain.Expenses;
using ExpenseShare.Domain.Rooms.Events;
using ExpenseShare.Domain.Users;

namespace ExpenseShare.Domain.Rooms
{
    public sealed class Room : Entity
    {
        public Name Name { get; private set; }

        public Code RoomCode { get; private set; }

        private readonly List<User> _users = [];
        public IReadOnlyCollection<User> Users => _users;

        private readonly List<Expense> _expenses = [];
        public IReadOnlyCollection<Expense> Expenses => _expenses;

        private Room(Guid id, Name name, Code code): base(id)
        {
            Name = name;
            RoomCode = code;
        }

        public Room()
        {
            
        }

        public static Room Create(Name name)
        {
            var room = new Room(Guid.NewGuid(), name, Code.NewCode());

            room.RaiseDomainEvent(new RoomCreatedDomainEvent(room.Id));

            return room;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void RemoveUser(User user)
        {
            _users.Remove(user);
        }
    }
}
