using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyaiCoach.Application.Const;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using MyaiCoach.Domain.Dtos.Base;
using MyaiCoach.Domain.Enums;
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

        public async Task<IEnumerable<IBaseViewDto>> ConversationAsync(string text, ReqType reqType)
        {
            string message;

            if (reqType == ReqType.Workout)
            {
                message = Messages.Workout;
            }
            else
            {
                message = Messages.Nutrition;
            }

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

                    if (reqType == ReqType.Workout)
                    {
                        var programViews = JsonConvert.DeserializeObject<List<ProgramViewDto>>(parts);
                        return programViews;
                    }
                    else
                    {
                        var dietProgramViews = JsonConvert.DeserializeObject<List<DietProgramViewDto>>(parts);
                        return dietProgramViews;
                    }
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

            return new List<IBaseViewDto>();
        }
    }
}

