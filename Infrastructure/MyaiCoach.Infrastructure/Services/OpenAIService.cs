using Microsoft.Extensions.Configuration;
using MyaiCoach.Application.Const;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.Base;
using MyaiCoach.Domain.Enums;
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


        public async Task<IEnumerable<IBaseViewDto>> ConversationAsync(string text, ReqType reqtype)
        {
            var chat = _openAIAPI.Chat.CreateConversation();
            
            if(reqtype == ReqType.Workout)
                chat.AppendSystemMessage(Messages.Workout);

            else
                chat.AppendSystemMessage(Messages.Nutrition);

            chat.AppendUserInput(text);

            var stringBuilder = new StringBuilder();

            await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                stringBuilder.Append(res);
            }

            var result =  stringBuilder.ToString();


            IEnumerable<IBaseViewDto> data = null;


            if (reqtype == ReqType.Workout)
                JsonConvert.DeserializeObject<List<ProgramViewDto>>(result);
            else
                JsonConvert.DeserializeObject<List<DietProgramViewDto>>(result);


            return data ?? throw new InvalidOperationException("Data parse not correct!");

        }
    }
}
