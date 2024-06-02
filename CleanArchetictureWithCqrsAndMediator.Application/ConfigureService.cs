using CleanArchetictureWithCqrsAndMediator.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application
{
    public static class ConfigureService
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(mr =>
            {
                mr.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                mr.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviours<,>));
            });
            return services;
        }
    }
}
