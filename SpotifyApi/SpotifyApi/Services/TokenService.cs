namespace SpotifyApi.Services
{
    public class TokenService : ITokenService
    {
        private static string _accessToken;
        public string GetAccessToken()
        {
            return _accessToken;
        }

        public void SetAccessToken(string token)
        {
            _accessToken = token;
        }
    }
}
