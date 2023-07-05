namespace ESG_Rest_Server_Application.CustomerDetails.Domain
{
    public class CreateResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; } = string.Empty;

        public CreateResult(bool success, string message = null)
        {
            Success = success;
            Message = message != null ? message : string.Empty;
        }
    }
}
