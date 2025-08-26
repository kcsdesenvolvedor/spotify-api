namespace SpotifyApi.Services
{
    public interface ITokenService
    {
        string GetAccessToken();
        void SetAccessToken(string token);
    }
}
