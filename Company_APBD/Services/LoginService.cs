using Company_APBD.Data;
using Company_APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_APBD.Services;

public class LoginService : ILoginService
{
    public DatabaseContext Context;

    public LoginService(DatabaseContext context)
    {
        Context = context;
    }
    
    public async Task RegisterUser(Employee user)
    {
        await Context.Employee.AddAsync(user);
        await Context.SaveChangesAsync();
    }
    
    public async Task<Employee> GetUser(string name)
    {
        return await Context.Employee.FirstOrDefaultAsync(u => u.Login == name );
    }

    public async Task SetUserToken(Employee u, string token)
    {
        u.RefreshToken = token;
        await Context.SaveChangesAsync();
    }

    public async Task<Employee> GetUserByToken(string token)
    {
        return await Context.Employee.FirstOrDefaultAsync(u => u.RefreshToken == token);
    }
}