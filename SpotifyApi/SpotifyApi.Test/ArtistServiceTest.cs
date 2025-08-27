using Moq;
using SpotifyApi.Data;
using SpotifyApi.Models;
using SpotifyApi.Services;
using Xunit;

namespace SpotifyApi.Test
{
    public class ArtistServiceTest
    {
        private readonly Mock<IArtitService> _artistServiceMock;
        public ArtistServiceTest()
        {
            _artistServiceMock = new Mock<IArtitService>();
        }

        [Fact]
        public async void DeveRetornarTodosOsArtistas()
        {
            // Arrange
            _artistServiceMock.Setup(service => service.GetAllArtistsAsync())
                .ReturnsAsync(new List<ArtistSimpleModel>
                {
                    new ArtistSimpleModel { Id = "1", Name = "Artist 1", Popularity = 10 },
                    new ArtistSimpleModel { Id = "2", Name = "Artist 2", Popularity = 20 }
                });
            // Act
            var result = await _artistServiceMock.Object.GetAllArtistsAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void DeveRetornarArtistaPorId()
        {
            // Arrange
            var artistId = "1";
            _artistServiceMock.Setup(service => service.GetArtistByIdAsync(artistId))
                .ReturnsAsync(new ArtistSimpleModel { Id = artistId, Name = "Artist 1", Popularity = 10 });
            // Act
            var result = await _artistServiceMock.Object.GetArtistByIdAsync(artistId);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(artistId, result.Id);
        }

        [Fact]
        public async void DeveRetornarArtistasPorPopularidade()
        {
            // Arrange
            var minPopularity = 10;
            var maxPopularity = 20;
            _artistServiceMock.Setup(service => service.GetArtistsByPopularity(minPopularity, maxPopularity))
                .ReturnsAsync(new List<ArtistSimpleModel>
                {
                    new ArtistSimpleModel { Id = "1", Name = "Artist 1", Popularity = 10 },
                    new ArtistSimpleModel { Id = "2", Name = "Artist 2", Popularity = 20 }
                });
            // Act
            var result = await _artistServiceMock.Object.GetArtistsByPopularity(minPopularity, maxPopularity);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task NaoDeveInserirArtistaQuandoArtistaJaExistir()
        {
            // Arrange
            var mockRepo = new Mock<IArtistSimpleRepository>();
            var artist = new ArtistSimpleModel { Id = "123", Name = "Test Artist", Popularity = 10 };

            // Simula que o artista já existe
            mockRepo.Setup(r => r.GetArtistByIdAsync(artist.Id))
                    .ReturnsAsync(artist);

            // Act
            await _artistServiceMock.Object.InsertArtistSimple(artist);

            // Assert
            mockRepo.Verify(r => r.InsertArtistSimple(It.IsAny<ArtistSimpleModel>()), Times.Never);
        }
    }
}