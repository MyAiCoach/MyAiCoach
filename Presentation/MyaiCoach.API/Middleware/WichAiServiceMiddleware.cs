using MyaiCoach.Application.Services;
using MyaiCoach.Infrastructure.Services;

namespace MyaiCoach.API.Middleware
{
    public class WichAiServiceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public WichAiServiceMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("aiservice", out var aiService))
            {
                IAiServices aiServiceInstance = aiService.ToString() switch
                {
                    "GeminiAIService" => _serviceProvider.GetService<GeminiAIService>(),
                    "OpenAIService" => _serviceProvider.GetService<OpenAIService>(),
                    _ => throw new ArgumentException($"Unknown AI service: {aiService}")
                };

                if (aiServiceInstance != null)
                {
                    context.Items["AiService"] = aiServiceInstance;
                }
            }

            await _next.Invoke(context);
            return;
        }
    }
}
