namespace SharedModels.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public object Result { get; set; }
    }
}
