using Microsoft.Extensions.Configuration;
using MyaiCoach.Application.Const;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.Ai;
using MyaiCoach.Domain.Dtos.Base;
using MyaiCoach.Domain.Enums;
using MyaiCoach.Infrastructure.Utils;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyaiCoach.Infrastructure.Services
{
    public class OpenAIService : IAiServices
    {
        private readonly IConfiguration _configuration;
        private readonly OpenAIAPI _openAIAPI;

        public OpenAIService(IConfiguration configuration)
        {
            _configuration = configuration;
            _openAIAPI = new OpenAIAPI(_configuration["OpenAI:Key"]);
        }

        public async Task<IEnumerable<IBaseViewDto>> NutritionConversationAsync(CreateNutritionDto input)
        {
            var chat = _openAIAPI.Chat.CreateConversation();
            var text = GeneratePrompt.GenerateNutrition(input);

            chat.AppendSystemMessage(Messages.Nutrition);
            chat.AppendUserInput(text);

            var stringBuilder = new StringBuilder();

            await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                stringBuilder.Append(res);
            }

            var result = stringBuilder.ToString();
            var data = JsonConvert.DeserializeObject<List<DietProgramViewDto>>(result);

            return data;
        }

        public async Task<IEnumerable<IBaseViewDto>> WokoutConversationAsync(CreateWorkoutDto input)
        {
            var chat = _openAIAPI.Chat.CreateConversation();
            var text = GeneratePrompt.GenerateWorkout(input);

            chat.AppendSystemMessage(Messages.Workout);
            chat.AppendUserInput(text);

            var stringBuilder = new StringBuilder();

            await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                stringBuilder.Append(res);
            }

            var result = stringBuilder.ToString();
            var data = JsonConvert.DeserializeObject<List<ProgramViewDto>>(result);

            return data;
        }
    }
}
