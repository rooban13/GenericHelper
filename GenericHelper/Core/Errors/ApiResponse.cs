namespace GenericHelper.Core.Errors
{

    public class ApiResponse<T> : ApiResponse
    {
        T Result;
        public ApiResponse(T result, int statusCode, string message = null) : base(statusCode, message)
        {
            Result = result;
        }
    }
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "bad request",
                401 => "not authorized",
                404 => "resource not found",
                500 => "error",
                _ => null
            };
        }
    }
}
