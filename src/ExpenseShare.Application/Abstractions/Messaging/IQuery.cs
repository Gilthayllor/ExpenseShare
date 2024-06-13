using ExpenseShare.Domain.Abstractions;
using MediatR;

namespace ExpenseShare.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
