using Company_APBD.Models;


    public interface ILoginService
    {
        Task RegisterUser(Employee user);
        Task<Employee> GetUser(string login);
        Task SetUserToken(Employee u, string token);
        Task<Employee> GetUserByToken(string token);
    }
