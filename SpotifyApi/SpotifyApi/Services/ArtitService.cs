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

        public async void InsertArtistSimple(ArtistSimpleModel artist)
        {
            var artistExists = await _artistSimpleRepository.GetArtistByIdAsync(artist.Id);

            if (artistExists == null)
                _artistSimpleRepository.InsertArtistSimple(artist);
        }
    }
}
