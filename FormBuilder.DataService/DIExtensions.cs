using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using FormBuilder.DataService;
using FormBuilder.DataService.Implementations;

namespace FormBuilder
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
