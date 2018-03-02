using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BuilderForm.Repository;
using Microsoft.EntityFrameworkCore;

namespace BuilderForm
{
    public static class DIExtensions
    {
        public static void AddRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FormBuilderDbContext>(options =>
            {
                options.UseNpgsql(connectionString,
                    builder => builder.MigrationsAssembly("BuilderForm.API"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
