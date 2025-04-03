using EAppointment.Application.Abstractions.Commons.Exceptions;

namespace EAppointment.Application.Commons.Exceptions
{
    public readonly record struct ErrorType(byte Code, string Message) : IErrorType
    {
        public override string ToString() => $"{Code}: {Message}";

        public static readonly ErrorType NotFound = new(001, "Not Found");
        public static readonly ErrorType Unauthorized = new(002, "Unauthorized");
        public static readonly ErrorType BadRequest = new(003, "Bad Request");
        public static readonly ErrorType InternalServer = new(004, "Bad Request");
    }
}
