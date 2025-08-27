using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Services;
using System.Text.Json;

namespace SpotifyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ISpotifyApi _spotifyApi;
        private readonly IArtitService _artitService;

        public ArtistController(ISpotifyApi spotifyApi, IArtitService artitService)
        {
            _spotifyApi = spotifyApi;
            _artitService = artitService;
        }

        [HttpGet("GetArtistBySpotifyAPI")]
        public async Task<IActionResult> GetArtist(string id)
        {
            var artist = await _spotifyApi.GetArtistAsync(id);
            if (artist == null)
                return NotFound();

            var artistSimple = JsonSerializer.Deserialize<Models.ArtistSimpleModel>(artist);

            _artitService.InsertArtistSimple(artistSimple);
            return Ok(artistSimple);
        }

        [HttpGet("GetAllArtists")]
        public async Task<ActionResult> GetAllArtists()
        {
            var artists = await _artitService.GetAllArtistsAsync();
            return Ok(artists);
        }


        [HttpGet("GetArtistsByPopularity")]
        public async Task<IActionResult> GetArtistsByPopularity(int minPopularity, int maxPopularity)
        {
            var artists = await _artitService.GetArtistsByPopularity(minPopularity, maxPopularity);
            return Ok(artists);
        }
    }
}
