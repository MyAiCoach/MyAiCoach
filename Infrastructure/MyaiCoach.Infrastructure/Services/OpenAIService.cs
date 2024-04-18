using Microsoft.Extensions.Configuration;
using MyaiCoach.Application.Const;
using MyaiCoach.Application.Services;
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

        public async Task<string> CompleteSentenceAdvanceAsync(string text)
        {
            var result = await _openAIAPI.Completions.CreateCompletionAsync(
                new CompletionRequest()
                {
                    Prompt = text,
                    Model  =Model.DefaultModel,
                    Temperature = 0.1,
                });

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < result.Completions.Count; i++)
            {
                var x = result.Completions[i].Text.Trim();

                stringBuilder.Append($" {x}");
            }

            return stringBuilder.ToString();
        }

        public async Task<string> CompleteSentenceAsync(string text)
        {
            return await _openAIAPI.Completions.GetCompletion(text);
        }

        public async Task<string> ConversationAsync(string text)
        {
            var chat = _openAIAPI.Chat.CreateConversation();
            
            chat.AppendSystemMessage(Messages.WhoAmI);

            chat.AppendUserInput(text);

            var stringBuilder = new StringBuilder();

            await foreach (var res in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                stringBuilder.Append(res);
            }

            return stringBuilder.ToString();

        }

        public async Task<string> CreateChatCompletionAsync(string text)
        {

            var results = await _openAIAPI.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.1,
                MaxTokens = 50,
                Messages = new ChatMessage[]
                {
                    new ChatMessage(ChatMessageRole.User, text)
                }
            });

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < results.Choices.Count; i++)
            {
                var x = results.Choices[i].Message.Content.Trim();

                stringBuilder.Append($" {x}");
            }

            return stringBuilder.ToString();
        }
    }
}
