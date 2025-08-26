using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Services;

namespace SpotifyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ISpotifyApi _spotifyApi;

        public ArtistController(ISpotifyApi spotifyApi)
        {
            _spotifyApi = spotifyApi;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(string id)
        {
            var artist = await _spotifyApi.GetArtistAsync(id);
            return Ok(artist);
        }
    }
}
