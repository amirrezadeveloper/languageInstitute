namespace languageInstitute.Application.Wrappers;

public class Response<T>
{
    public Response() { }
    public Response(T data, string messsage = null)
    {

        Succeeded = true;
        Message = messsage;
        Data = data;
    }

    public Response(string message)
    {
        Succeeded = false;
        Message = message;
    }

    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }
}
