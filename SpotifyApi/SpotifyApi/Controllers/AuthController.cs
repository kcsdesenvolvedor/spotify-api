using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Services;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SpotifyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenService _tokenService;

        public AuthController(IHttpClientFactory httpClientFactory, ITokenService tokenService)
        {
            _httpClientFactory = httpClientFactory;
            _tokenService = tokenService;
        }

        [HttpGet()]
        public async Task<IActionResult> AccessToken(string clientId, string clientSecret)
        {
            var client = _httpClientFactory.CreateClient();

            var requestBody = new Dictionary<string, string>
        {
            {"grant_type", "client_credentials"},
            {"client_id", clientId},
            {"client_secret", clientSecret}
        };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"))
            );
            requestMessage.Content = new FormUrlEncodedContent(requestBody);

            var response = await client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenInfo = JsonSerializer.Deserialize<JsonElement>(responseContent);
            var accessToken = tokenInfo.GetProperty("access_token").GetString();

            _tokenService.SetAccessToken(accessToken);

            return Ok(new { AccessToken = accessToken });
        }
    }
}
