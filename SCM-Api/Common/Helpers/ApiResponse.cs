using System.Net;

namespace Common.Helpers
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            StatusCode = (int)HttpStatusCode.OK;
        }

        public ApiResponse(HttpStatusCode statusCode, List<string> messages)
        {
            StatusCode = (int)statusCode;
            Messages = messages;
        }

        public ApiResponse(HttpStatusCode statusCode, List<string> messages, dynamic? result)
        {
            StatusCode = (int)statusCode;
            Messages = messages;
            Result = result;
        }

        public int StatusCode { get; set; }

        public List<string> Messages { get; set; } = new List<string>();

        public dynamic? Result { get; set; }
    }
}

