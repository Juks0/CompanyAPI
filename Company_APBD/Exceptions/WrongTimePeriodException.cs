namespace WebApplication5.Exceptions;

public class WrongTimePeriodException : Exception
{
    public WrongTimePeriodException(string message) : base(message)
    {
    }
}