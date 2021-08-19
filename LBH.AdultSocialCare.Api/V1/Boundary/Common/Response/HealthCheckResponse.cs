namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class HealthCheckResponse
    {
        public HealthCheckResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
