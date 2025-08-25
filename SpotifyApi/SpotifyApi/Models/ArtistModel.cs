using System.Text.Json.Serialization;

namespace SpotifyApi.Models
{
    public class ArtistModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; }
        [JsonPropertyName("followers")]
        public Followers Followers { get; set; }
        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; }
        [JsonPropertyName("href")]
        public string Href { get; set; }
        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }

    public class ExternalUrls
    {
        [JsonPropertyName("spotify")]
        public string Spotify { get; set; }
    }

    public class Followers
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
    public class Image
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}
