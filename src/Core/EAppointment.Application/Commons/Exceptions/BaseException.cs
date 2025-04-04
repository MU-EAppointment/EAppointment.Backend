using EAppointment.Application.Abstractions.Commons.Exceptions;
using System.Net;
using System.Text;

namespace EAppointment.Application.Commons.Exceptions;

internal class BaseException(IErrorType Error, HttpStatusCode HttpStatusCode, Exception? innerException)
    : Exception(Error.Message, innerException)
{
    public IErrorType Error { get; } = Error;
    public HttpStatusCode HttpStatusCode { get; } = HttpStatusCode;

    internal BaseException(IErrorType error, HttpStatusCode httpStatusCode) : this(error, httpStatusCode, default){ }

    public override string ToString()
    {
        StringBuilder? stringBuilder = new(100);
        stringBuilder.Append("Error Code: ").Append(Error.Code)
          .Append(", Message: ").Append(Message)
          .Append(", HTTP Status: ").Append((int)HttpStatusCode)
          .Append(" ->").Append(HttpStatusCode);

        return stringBuilder.ToString();
    }
}
