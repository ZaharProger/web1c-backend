namespace web1c_backend.Models.Http.Responses
{
    public class DataResponse<T> : BaseResponse
    {
        public T[]? Data { get; set; }
    }
}
