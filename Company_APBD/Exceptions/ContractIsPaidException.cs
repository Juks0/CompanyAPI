namespace WebApplication5.Exceptions;

public class ContractIsPaidException : Exception
{
    public ContractIsPaidException(string message) : base(message)
    {
    }
}