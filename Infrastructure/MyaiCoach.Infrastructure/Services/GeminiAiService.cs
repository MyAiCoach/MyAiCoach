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
            var apiKey = _configuration["APIKey"];
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new
                            {
                                text = text
                            }
                        }
                    }
                }
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(url, httpContent);
                Console.Write(response);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    
                    var resultList = new List<ProgramViewDto>
                    {
                        new ProgramViewDto{}
                    };
                    return resultList;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Details: " + errorContent);

                    
                    return new List<ProgramViewDto>();
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                // Hata durumunda boş bir liste döndür
                return new List<ProgramViewDto>();
            }
        }
    }
}
