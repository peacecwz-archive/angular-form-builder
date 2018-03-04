using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using FormBuilder.Repository;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder
{
    public static class DIExtensions
    {
        public static void AddRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FormBuilderDbContext>(options =>
            {
                options.UseNpgsql(connectionString,
                    builder => builder.MigrationsAssembly("FormBuilder.API"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
