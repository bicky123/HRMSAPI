namespace HRMS.Comman.ApiResponse
{
    public class DataResponse<T> : Response where T : class
    {
        public T Data { get; }

        public DataResponse(int statusCode, T data, string message = "") : base(statusCode, message)
        {
            this.Data = data;
        }
    }
}
