using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using CleanArchetictureWithCqrsAndMediator.Infrastrcture.Data;
using CleanArchetictureWithCqrsAndMediator.Infrastrcture.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Infrastrcture
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastrcutreServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BlogDbContext")));
            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}
