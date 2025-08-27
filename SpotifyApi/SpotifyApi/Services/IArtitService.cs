using SpotifyApi.Models;

namespace SpotifyApi.Services
{
    public interface IArtitService
    {
        Task<ArtistSimpleModel> GetArtistByIdAsync(string id);
        void InsertArtistSimple(ArtistSimpleModel artist);
        Task<IEnumerable<ArtistSimpleModel>> GetAllArtistsAsync();
    }
}
