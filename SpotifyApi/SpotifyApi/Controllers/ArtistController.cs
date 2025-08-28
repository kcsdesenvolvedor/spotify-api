using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Models;
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
            try
            {
                var artist = await _spotifyApi.GetArtistAsync(id);
                if (artist == null)
                    return NotFound(new ErrorApiResponse("ARTIST_NOT_FOUND", "Artista não encontrado no Spotify."));

                var artistSimple = JsonSerializer.Deserialize<ArtistSimpleModel>(artist);

                await _artitService.InsertArtistSimple(artistSimple);

                return Ok(new SuccessApiResponse<ArtistSimpleModel>(true, "Artista recuperado com sucesso.", artistSimple));
            }
            catch (JsonException ex)
            {
                return BadRequest(new ErrorApiResponse("INVALID_JSON", "Erro ao processar os dados do artista.", ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorApiResponse("INTERNAL_ERROR", "Ocorreu um erro inesperado.", ex.Message));
            }
        }

        [HttpGet("GetAllArtists")]
        public async Task<IActionResult> GetAllArtists()
        {
            try
            {
                var artists = await _artitService.GetAllArtistsAsync();
                return Ok(new SuccessApiResponse<IEnumerable<ArtistSimpleModel>>(true, "Artistas recuperados com sucesso.", artists));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorApiResponse("INTERNAL_ERROR", "Erro ao buscar artistas.", ex.Message));
            }
        }

        [HttpGet("GetArtistsByPopularity")]
        public async Task<IActionResult> GetArtistsByPopularity(int minPopularity, int maxPopularity)
        {
            try
            {
                var artists = await _artitService.GetArtistsByPopularity(minPopularity, maxPopularity);
                return Ok(new SuccessApiResponse<IEnumerable<ArtistSimpleModel>>(true, "Artistas filtrados com sucesso.", artists));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorApiResponse("INTERNAL_ERROR", "Erro ao filtrar artistas.", ex.Message));
            }
        }
    }
}
