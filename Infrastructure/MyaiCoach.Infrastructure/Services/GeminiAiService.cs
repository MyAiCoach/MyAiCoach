using Microsoft.Extensions.Configuration;
using MyaiCoach.Application.Services;
using MyaiCoach.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<ProgramViewDto>> ConversationAsync(string text)
        {
            string googleApiKey = "ApiKey";
        string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key=" + googleApiKey;
        Console.Write("Input : ");
        string requestBody = $@"{{
            ""contents"": [
                {{
                    ""parts"":[
                        {{
                            ""text"": ""{text}""
                        }}
                    ]
                }}
            ]
        }}";

        try
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
                else
                {
                    Console.WriteLine("Failed to get response. Status code: " + response.StatusCode);
                }
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
