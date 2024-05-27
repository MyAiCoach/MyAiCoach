using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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

        public GeminiAIService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public async Task<List<ProgramViewDto>> ConversationAsync(string text,ReqType reqtypes)
        {
            string dev_text = "You are an expert fitness instructor. You know everything about exercises and diet programs. People will ask you for advice on healthy living, exercise programs, and diet plans. You will give them the most appropriate answers based on the health information they share with you. The person asking the question does not have any health problems. Think of the days as Monday 1, Tuesday 2, ... Sunday 7. You will not deviate from this format. Even if it's the same value, I'll fill in the sets and reps for each move. If possible, I will put it on an off day. I will just follow the format above, ready to add to the table. My format is (you answer me only json data. this is important): [ { \"day\": 1, \"exercises\": [ { \"name\": \"string\", \"description\": \"string\", \"targetArea\": \"string\" } ], \"setReps\": [ { \"set\": 0, \"rep\": 0 } ] } ],";

            string googleApiKey = "AIzaSyCuOye7z19PyR4WgLniLk6TjmyCrwM7aJs";
            string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={googleApiKey}";

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
                                text = $"{dev_text} {text}"
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
                    var programViews = JsonConvert.DeserializeObject<List<ProgramViewDto>>(parts);
                    return programViews;
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

        public Task<IEnumerable<IBaseViewDto>> ConversationAsync(string text, ReqType reqtype)
        {
            throw new NotImplementedException();
        }
    }
}


    