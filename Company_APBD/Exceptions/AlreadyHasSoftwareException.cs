namespace WebApplication5.Exceptions;

public class AlreadyHasSoftwareException : Exception
{
    public AlreadyHasSoftwareException(string message) : base(message)
    {
    }
}