using Microsoft.Extensions.DependencyInjection;
using MyaiCoach.Application.Services;
using MyaiCoach.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAiServices, GeminiAIService>();
        }
    }
}
