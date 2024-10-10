using System.Net;

namespace Domain.Shared;

public class Result<T> : Result
{
    private readonly T? _data;

    protected internal Result(
        T? data,
        bool isSuccess,
        HttpStatusCode statusCode,
        Error? error = null)
        : base(isSuccess, statusCode, error)
        => _data = data;

    public T Data => _data!;
}

public class Result
{
    protected internal Result(bool isSuccess, HttpStatusCode statusCode, Error? error = null)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        Error = error;
    }

    public bool IsSuccess { get; }
    public Error? Error { get; }
    public HttpStatusCode StatusCode { get; }
    public bool IsFailure => !IsSuccess;

    public static Result Success(HttpStatusCode statusCode = HttpStatusCode.NoContent) =>
        new(true, statusCode);

    public static Result<T> Success<T>(T data, HttpStatusCode statusCode = HttpStatusCode.OK) =>
        new(data, true, statusCode);

    public static Result Failure(Error error, HttpStatusCode statusCode) =>
        new(false, statusCode, error);

    public static Result<T> Failure<T>(Error error, HttpStatusCode statusCode) =>
        new(default, false, statusCode, error);
}
