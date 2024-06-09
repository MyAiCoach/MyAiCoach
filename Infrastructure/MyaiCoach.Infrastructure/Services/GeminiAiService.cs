using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyaiCoach.Application.Const;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.Ai;
using MyaiCoach.Domain.Dtos.Base;
using MyaiCoach.Domain.Enums;
using MyaiCoach.Infrastructure.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyaiCoach.Infrastructure.Services
{
    public class GeminiAIService : IAiServices
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _googleApiKey;

        public GeminiAIService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
            _googleApiKey = _configuration["GeminiAI:key"];
        }
        public async Task<IEnumerable<DietProgramViewDto>> NutritionConversationAsync(CreateNutritionDto input)
        {
            string message;
            string text = GeneratePrompt.GenerateNutrition(input);

            message = Messages.Nutrition;

            string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={_googleApiKey}";

            var requestBodyObject = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = $"{message} {text}"
                            }
                        }
                    }
                }
            };

            string requestBody = JsonConvert.SerializeObject(requestBodyObject);

            try
            {
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(responseContent);
                    var parts = jsonObject["candidates"][0]["content"]["parts"][0]["text"].ToString();
                    Console.WriteLine(parts);

                    var dietDrogramView = JsonConvert.DeserializeObject<List<DietProgramViewDto>>(parts);
                    return dietDrogramView;
                }
                else
                {
                    Console.WriteLine("Failed to get response. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
            }

            return new List<DietProgramViewDto>();
        }

        public async Task<IEnumerable<ProgramViewDto>> WokoutConversationAsync(CreateWorkoutDto input)
        {
            string message;
            string text = GeneratePrompt.GenerateWorkout(input);

                message = Messages.Workout;

            string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={_googleApiKey}";

            var requestBodyObject = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = $"{message} {text}"
                            }
                        }
                    }
                }
            };

            string requestBody = JsonConvert.SerializeObject(requestBodyObject);

            try
            {
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(responseContent);
                    var parts = jsonObject["candidates"][0]["content"]["parts"][0]["text"].ToString();
                    Console.WriteLine(parts);

                    var programView = JsonConvert.DeserializeObject<List<ProgramViewDto>>(parts);
                    return programView;
                }
                else
                {
                    Console.WriteLine("Failed to get response. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
            }

            return new List<ProgramViewDto>();
        }
    }
}

