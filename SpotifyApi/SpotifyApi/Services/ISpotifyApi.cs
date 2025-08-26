using Refit;

namespace SpotifyApi.Services
{
    [Headers("accept: application/json", "Authorization: Bearer {accessToken}")]
    public interface ISpotifyApi
    {
        [Get("/v1/artists/{id}")]
        Task<string> GetArtistAsync(string id, string accessToken);
    }
}
