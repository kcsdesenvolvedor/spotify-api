using SpotifyApi.Models;

namespace SpotifyApi.Data
{
    public interface IArtistSimpleRepository
    {
        Task<ArtistSimpleModel> GetArtistByIdAsync(string id);
        void InsertArtistSimple(ArtistSimpleModel artist);
        Task<IEnumerable<ArtistSimpleModel>> GetAllArtistsAsync();
        Task<IEnumerable<ArtistSimpleModel>> GetArtistsByPopularity(int minPopularity, int maxPopularity);
    }
}
