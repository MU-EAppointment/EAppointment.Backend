namespace EAppointment.Application.Abstractions.Commons.Exceptions
{
    public interface IErrorType
    {
        byte Code { get; }
        string Message { get; }
    }
}
