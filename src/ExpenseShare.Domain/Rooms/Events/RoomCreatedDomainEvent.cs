using ExpenseShare.Domain.Abstractions;

namespace ExpenseShare.Domain.Rooms.Events
{
    public sealed record RoomCreatedDomainEvent(Guid RoomId) : IDomainEvent;
}
