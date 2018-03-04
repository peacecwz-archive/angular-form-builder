using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BuilderForm.DataService;
using BuilderForm.DataService.Implementations;

namespace BuilderForm
{
    public static class DIExtensions
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IFormAnswerService, FormAnswerService>();
        }
    }
}
