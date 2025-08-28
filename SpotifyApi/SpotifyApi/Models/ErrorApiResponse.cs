namespace SpotifyApi.Models
{
    public class ErrorApiResponse
    {
        public bool Success { get; set; } = false;
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string? Details { get; set; }

        public ErrorApiResponse(string errorCode, string message, string? details = null)
        {
            ErrorCode = errorCode;
            Message = message;
            Details = details;
        }
    }
}
