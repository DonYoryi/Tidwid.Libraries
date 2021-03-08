namespace Tidwit.Libraries.Api.Models
{
    using Newtonsoft.Json;

    public class ErrorResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("intance")]
        public string Instance { get; set; }

        public ErrorResponse()
        {
        }

        public ErrorResponse(string message, int status, string intance)
        {
            this.Message = message;
            this.Status = status;
            this.Instance = intance;
        }

    }

}
