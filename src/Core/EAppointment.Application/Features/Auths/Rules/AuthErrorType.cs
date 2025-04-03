using EAppointment.Application.Abstractions.Commons.Exceptions;
using EAppointment.Application.Commons.Exceptions;

namespace EAppointment.Application.Features.Auths.Rules
{
    public readonly record struct AuthErrorType(byte Code, string Message) : IErrorType
    {
        public static readonly ErrorType UserNotFound = new(010, "User Not Found");
        public static readonly ErrorType PasswordNotCorrect = new(011, "Password Not Correct");
    }
}
