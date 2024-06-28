namespace WebApplication5.Exceptions;

public class WrongReasourceException : Exception
{
    public WrongReasourceException(string message) : base(message)
    {
    }
}