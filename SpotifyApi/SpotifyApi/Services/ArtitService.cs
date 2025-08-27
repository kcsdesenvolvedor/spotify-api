using SpotifyApi.Data;
using SpotifyApi.Models;

namespace SpotifyApi.Services
{
    public class ArtitService : IArtitService
    {
        private readonly IArtistSimpleRepository _artistSimpleRepository;

        public ArtitService(IArtistSimpleRepository artistSimpleRepository)
        {
            _artistSimpleRepository = artistSimpleRepository;
        }

        public async Task<IEnumerable<ArtistSimpleModel>> GetAllArtistsAsync()
        {
            return await _artistSimpleRepository.GetAllArtistsAsync();
        }

        public async Task<ArtistSimpleModel> GetArtistByIdAsync(string id)
        {
            return await _artistSimpleRepository.GetArtistByIdAsync(id);
        }

        public void InsertArtistSimple(ArtistSimpleModel artist)
        {
            _artistSimpleRepository.InsertArtistSimple(artist);
        }
    }
}
