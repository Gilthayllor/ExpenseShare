using ExpenseShare.Application.Abstractions.Messaging;

namespace ExpenseShare.Application.Rooms.CreateRoom
{
    public sealed record CreateRoomCommand(
        string Name
        ) : ICommand<Guid>;
}
