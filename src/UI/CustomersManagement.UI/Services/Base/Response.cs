namespace CustomersManagement.UI.Services.Base;

public class Response<T>
{
    public string Message { get; set; }
    public string VadlidationErros { get; set; }
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
}
