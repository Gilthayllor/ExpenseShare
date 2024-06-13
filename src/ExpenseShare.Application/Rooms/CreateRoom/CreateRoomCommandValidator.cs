using FluentValidation;

namespace ExpenseShare.Application.Rooms.CreateRoom
{
    internal sealed class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
