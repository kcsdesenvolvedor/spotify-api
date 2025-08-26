using Refit;

namespace SpotifyApi.Services
{
    public interface ISpotifyApi
    {
        [Get("/v1/artists/{id}")]
        Task<string> GetArtistAsync(string id);
    }
}
