using AutoMapper.Configuration.Annotations;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Common.Behaviours
{
    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>>? _validators;
        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators.Any())
            {
                var validator = new ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validator, cancellationToken)));
                var faliors = validationResult.Where(r=>r.Errors.Any()).SelectMany(r=>r.Errors).ToList();
                if(faliors.Any())
                {
                    throw new ValidationException(faliors);
                }
            }
            return await next();
        }
    }
}
