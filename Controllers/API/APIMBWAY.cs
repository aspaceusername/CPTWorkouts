using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CPTWorkouts.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIMBWAY : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public APIMBWAY(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost]
        public async Task<ActionResult> pagarMBWAY()
        {
            // Prepare the request body
            var requestBody = "{\"payment\": {\"amount\": {\"currency\": \"EUR\"}}}";

            // Prepare the request content
            var requestContent = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json");

            // Make the POST request
            var response = await _httpClient.PostAsync("https://sandbox.eupago.pt/api/v1.02/mbway/create", requestContent);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Optionally, you can handle the response here
                // For example, you might want to read the response body:
                // var responseBody = await response.Content.ReadAsStringAsync();

                // Return an Ok response
                return Ok();
            }
            else
            {
                // If the request was not successful, return a failure status code
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}
