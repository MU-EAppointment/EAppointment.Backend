using System.Net;

namespace EAppointment.Application.Commons.Results
{
    public readonly record struct Error(string Code, string Message);

    public readonly struct Result<T>
    {
        public bool IsSucceded { get; }
        public T? Data { get; }
        public string Message { get; }
        public ReadOnlyMemory<Error> Errors { get; }
        public HttpStatusCode HttpStatusCode { get; }

        private Result(bool isSucceeded, T? data, string message, ReadOnlyMemory<Error> errors, HttpStatusCode httpStatusCode)
        {
            IsSucceded = isSucceeded;
            Data = data;
            Message = message;
            Errors = errors;
            HttpStatusCode = httpStatusCode;
        }
        public static Result<T> Success(T data, string message = "Success", HttpStatusCode httpStatusCode = HttpStatusCode.OK) => new(true, data, message, ReadOnlyMemory<Error>.Empty, httpStatusCode);

        public static Result<T> Fail(string code, string message, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            Error error = new(code, message);
            return new Result<T>(false, default, message, new[] { error }, httpStatusCode);
        }
        public static Result<T> Fail(Error[] errors, string message = "Error", HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest) => new(false, default, message, errors.AsMemory(), httpStatusCode);
    }

}
