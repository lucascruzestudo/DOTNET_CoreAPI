namespace Project.Domain.Common;
public class ResponseBase<T>
{
    public bool IsSuccess => !Errors.Any();
    public T? Data { get; set; }
    public IEnumerable<string> Errors { get; private set; } = [];
    public IEnumerable<string> Messages { get; private set; } = [];

    public ResponseBase(T data, IEnumerable<string> messages)
    {
        Data = data;
        Messages = messages;
    }

    public ResponseBase(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public static ResponseBase<object> Failure(string error)
    {
        return new ResponseBase<object>([error]);
    }

    public static ResponseBase<object> Failure(IEnumerable<string> errors)
    {
        return new ResponseBase<object>(errors);
    }

    public static ResponseBase<T> Success(T data)
    {
        return new ResponseBase<T>(data, []);
    }
    public static ResponseBase<T> Success(T data, IEnumerable<string> messages)
    {
        return new ResponseBase<T>(data, messages);
    }
}
