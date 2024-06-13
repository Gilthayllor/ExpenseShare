using ExpenseShare.Application.Abstractions.Messaging;
using ExpenseShare.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace ExpenseShare.Application.Abstractions.Behaviors
{
    internal class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(x => x.Validate(context))
                .Where(x => x.Errors.Any())
                .SelectMany(x => x.Errors)
                .Select(x => new ValidationError(x.PropertyName, x.ErrorMessage));


            if (errors.Any())
            {
                throw new Exceptions.ValidationException(errors);
            }

            return await next();
        }
    }
}
