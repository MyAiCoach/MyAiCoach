using Microsoft.AspNetCore.Http;
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
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<GeminiAIService>();
            serviceCollection.AddTransient<OpenAIService>();
            serviceCollection.AddScoped(provider =>
            {
                var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var httpContext = httpContextAccessor.HttpContext;
                return httpContext?.Items["AiService"] as IAiServices
                       ?? throw new ArgumentNullException("AI Service is not available in HttpContext.");
            });
        }
    }
}
