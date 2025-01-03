﻿using FluentValidation;
using Interviewbot_API.BuildingBlocks.Application;
using Interviewbot_API.Modules.Auth.Application.Contracts;
using MediatR;

namespace Interviewbot_API.Modules.Auth.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand, ICommand<TRequest>, IQuery<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = await Task.WhenAll(
            _validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));

        var errors = validationFailures
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .ToList();

        if (errors.Any())
        {
            throw new InvalidCommandException(errors.Select(x => x.ErrorMessage).ToList());
        }

        return await next();
    }
}