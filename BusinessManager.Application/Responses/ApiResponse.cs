namespace BusinessManager.Application.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<ApiError> Errors { get; set; } = new();
        public string RequestId { get; set; }

        // ---- Factory helpers (VERY IMPORTANT) ----

        public static ApiResponse<T> Ok(T data, string message)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                RequestId = Guid.NewGuid().ToString()
            };
        }

        public static ApiResponse<T> Ok(string message)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = default,
                RequestId = Guid.NewGuid().ToString()
            };
        }

        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = default,
                RequestId = Guid.NewGuid().ToString()
            };
        }
    }

    public class ApiError
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
