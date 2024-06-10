using ExpenseShare.Domain.Abstractions;
using ExpenseShare.Domain.Rooms;
using ExpenseShare.Domain.Users.Events;

namespace ExpenseShare.Domain.Users
{
    public sealed class User : Entity
    {
        public Name Name { get; private set; }

        public Email Email { get; private set; }

        public Guid RoomId { get; private set; }
        
        public Room Room { get; private set; }

        private User(Guid id, Name name, Email email) :base(id)
        {
            Name = name;
            Email = email;
        }

        private User() { }

        public static User Create(Name name, Email email)
        {
            var user = new User(Guid.NewGuid(), name, email);

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }
    }
}
