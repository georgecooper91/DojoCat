using DojoCat.Members.Common.Errors;

namespace DojoCat.Members.Common.Result;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.Success ||
            !isSuccess && error == Error.Success)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new(true, Error.Success);

    public static Result<TValue> Success<TValue>(TValue? value)
        where TValue : class
        => new Result<TValue>(value, true, Error.Success);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Failure<TValue>(TValue? value, Error error) 
        where TValue : class
        => new Result<TValue>(value, false, error);

}

public class Result<T> : Result
{
    public T Value { get; }

    protected internal Result(T value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        Value = value;
    }
}