using System.Text.Json.Serialization;

namespace SpotifyApi.Models
{
    public class ArtistSimpleModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }
    }
}
