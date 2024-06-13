using ExpenseShare.Application.Abstractions.Messaging;

namespace ExpenseShare.Application.Users.RegisterUser
{
    public sealed record RegisterUserCommand(
        string FirstName,
        string LastName,
        string Email
        ) : ICommand<Guid>;
}
