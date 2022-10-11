namespace AdministrativeService.Database
{
    public class ApiResponse<T>
    {
            public bool Success { get; set; }
            public T Message { get; set; }

            public ApiResponse(bool success, T message)
            {
                Success = success;
                Message = message;
            }
        
    }
}
