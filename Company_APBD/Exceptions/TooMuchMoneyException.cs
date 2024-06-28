namespace WebApplication5.Exceptions;

public class TooMuchMoneyException : Exception
{
    public TooMuchMoneyException(string message) : base(message)
    {
    }
}