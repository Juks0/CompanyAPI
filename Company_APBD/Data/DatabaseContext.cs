using Company_APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_APBD.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<CompanyCustomer> CompanyCustomer { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomer { get; set; }
    public DbSet<ContractIndividualCustomer> ContractIndividualCustomers { get; set; }
    public DbSet<ContractCompanyCustmer> ContractCompanyCustmers { get; set; }
    public DbSet<Software> Software { get; set; }
    public DbSet<Discount> Discount { get; set; }
    public DbSet<Employee> Employee { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
       
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role() { RoleID = 1, Name = "Admin" },
            new Role() { RoleID = 2, Name = "User" }
        );
        modelBuilder.Entity<Discount>().HasData(
            new Discount() { DiscountID = 1, Value = 0.1m , Name = "Discount1", DiscountType = "Type1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10)},
            new Discount() { DiscountID = 2, Value = 0.2m , Name = "Discount2", DiscountType = "Type2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10)},
            new Discount() { DiscountID = 3, Value = 0.3m, Name = "Discount3", DiscountType = "Type3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(10)}
        );
        modelBuilder.Entity<Software>().HasData(
            new Software() { SoftwareID = 1, Name = "Software1", Price = 100, Description = "Description1", CurrentVersion = "1.0", Category = "Category1" },
            new Software() { SoftwareID = 2, Name = "Software2", Price = 200, Description = "Description2", CurrentVersion = "2.0", Category = "Category2" },
            new Software() { SoftwareID = 3, Name = "Software3", Price = 300, Description = "Description3", CurrentVersion = "3.0", Category = "Category3" }
        );
        modelBuilder.Entity<IndividualCustomer>().HasData(
            new IndividualCustomer() {FirstName = "FirstName1", LastName = "LastName1", Email = "Email1", PhoneNumber = "PhoneNumber1", CustomerID = 1,Address = "Wolecinska",PESEL = "12345678901"},
            new IndividualCustomer() {FirstName = "FirstName2", LastName = "LastName2", Email = "Email2", PhoneNumber = "PhoneNumber2", CustomerID = 2,Address = "Krasnalska",PESEL = "23345678901"},
            new IndividualCustomer() {FirstName = "FirstName3", LastName = "LastName3", Email = "Email3", PhoneNumber = "PhoneNumber3", CustomerID = 3,Address = "Krasnalska",PESEL = "22345678901"}
        );
        modelBuilder.Entity<CompanyCustomer>().HasData(
            new CompanyCustomer()
                { CompanyName = "CompanyName1",KRS = "111111111",Email = "Email1", PhoneNumber = "PhoneNumber1",Address = "Krasnalska", CustomerID = 4 },
            new CompanyCustomer()
                { CompanyName = "CompanyName2",KRS="123456789", Email = "Email2", PhoneNumber = "PhoneNumber2",Address = "Trakt lubelski", CustomerID = 5 },
            new CompanyCustomer()
                { CompanyName = "CompanyName3",KRS="123336722", Email = "Email3", PhoneNumber = "PhoneNumber3",Address = "grrpowska", CustomerID = 6 }
        );
        
            
    
            base.OnModelCreating(modelBuilder);
        }
   

    
}