using Dapper;
using Microsoft.Data.SqlClient;
using SpotifyApi.Models;

namespace SpotifyApi.Data
{
    public class ArtistSimpleRepository : IArtistSimpleRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ArtistSimpleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ArtistSimpleModel>> GetAllArtistsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Artists";
                var artists = await connection.QueryAsync<ArtistSimpleModel>(sql);
                return artists;
            }
        }

        public async Task<ArtistSimpleModel> GetArtistByIdAsync(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Artists WHERE Id = @Id";
                var artist = await connection.QuerySingleOrDefaultAsync<ArtistSimpleModel>(sql, new { Id = id });
                return artist;
            }
        }

        public async void InsertArtistSimple(ArtistSimpleModel artist)
        {
            var sql = "INSERT INTO Artists (Id, Name, Popularity) VALUES (@Id, @Name, @Popularity)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sql, new { artist.Id, artist.Name, artist.Popularity });
            }
        }
    }
}
