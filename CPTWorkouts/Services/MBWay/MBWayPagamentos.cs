using Azure;
using CPTWorkouts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
namespace CPTWorkouts.Services.MBWayPagamentos
{
    public class MBWayPagamentos
    {
        public async static Task<string> MBWayPay(decimal preco, string telemovel) {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://sandbox.eupago.pt/api/v1.02/mbway/create"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", "ApiKey demo-ed56-83d1-1326-cb5" },
                },
                Content = new StringContent("{\"payment\":{\"amount\":{\"currency\":\"EUR\",\"value\":"+preco+"},\"customerPhone\":\""+telemovel+"\",\"countryCode\":\"+351\"}}")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
