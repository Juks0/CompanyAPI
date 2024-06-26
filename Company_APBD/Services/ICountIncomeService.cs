namespace Company_APBD.Services;

public interface ICountIncomeService
{
    Task<decimal> CountPostedIncome();
    Task<decimal> CountUnpostedIncome();
}