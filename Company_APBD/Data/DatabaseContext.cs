using Company_APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_APBD.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CompanyCustomer> CompanyCustomer { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomer { get; set; }
    public DbSet<Subscription> Subscription { get; set; }
    public DbSet<Contract> Contract { get; set; }
    public DbSet<Software> Software { get; set; }
    public DbSet<Discount> Discount { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Employee> Employee { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        


        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<IndividualCustomer>().HasData(new List<IndividualCustomer>()
        {
            new IndividualCustomer
            {
                CustomerId = 1, Address = "707 Willow St, Gdansk, Poland",
                Email = "info@company5.com",
                PhoneNumber = "+48101234568", FirstName = "John", LastName = "Doe", PESEL = "12345678901"
            },
            new IndividualCustomer
            {
                CustomerId = 2, Address = "808 Maple St, Warsaw, Poland",
                Email = "jane.smith@example.com", PhoneNumber = "+48234567890", FirstName = "Jane", LastName = "Smith",
                PESEL = "23456789012"
            },
            new IndividualCustomer
            {
                CustomerId = 3, Address = "909 Oak St, Krakow, Poland",
                Email = "alice.johnson@example.com", PhoneNumber = "+48345678901", FirstName = "Alice", LastName = "Johnson",
                PESEL = "34567890123"
            },
            new IndividualCustomer
            {
                CustomerId = 4, Address = "1010 Pine St, Wroclaw, Poland",
                Email = "bob.brown@example.com", PhoneNumber = "+48456789012", FirstName = "Bob", LastName = "Brown",
                PESEL = "45678901234"
            },
            new IndividualCustomer
            {
                CustomerId = 5, Address = "1111 Cedar St, Poznan, Poland",
                Email = "carol.davis@example.com", PhoneNumber = "+48567890123", FirstName = "Carol", LastName = "Davis",
                PESEL = "56789012345"
            }
         
        });

        modelBuilder.Entity<CompanyCustomer>().HasData(new List<CompanyCustomer>()
        {
            new CompanyCustomer
            {
                CustomerId = 6, CompanyName = "Company 1", Address = "123 Birch St, Warsaw, Poland",
                Email = "info@company1.com", PhoneNumber = "+48678901234", KRS = "1234567890"
            },
            new CompanyCustomer
            {
                CustomerId = 7, CompanyName = "Company 2", Address = "234 Pine St, Krakow, Poland",
                Email = "info@company2.com", PhoneNumber = "+48789012345", KRS = "2345678901"
            },
            new CompanyCustomer
            {
                CustomerId = 8, CompanyName = "Company 3", Address = "345 Oak St, Poznan, Poland",
                Email = "info@company3.com", PhoneNumber = "+48890123456", KRS = "3456789012"
            },
            new CompanyCustomer
            {
                CustomerId = 9, CompanyName = "Company 4", Address = "456 Maple St, Wroclaw, Poland",
                Email = "info@company4.com", PhoneNumber = "+48901234567", KRS = "4567890123"
            },
            new CompanyCustomer
            {
                CustomerId = 10, CompanyName = "Company 5", Address = "567 Willow St, Gdansk, Poland",
                Email = "info@company5.com", PhoneNumber = "+48101234568", KRS = "5678901234"
            }
        });

        
        modelBuilder.Entity<Software>().HasData(new List<Software>()
        {
            new Software
            {
               SoftwareId = 1,Name = "Finance Pro",Price = 500,Description = "Financial management software", CurrentVersion = "1.0",
                Category = "Finance"
            },
            new Software
            {
                SoftwareId = 2, Name = "Edu Learn",Price = 100, Description = "Educational software for schools", CurrentVersion = "2.1",
                Category = "Education"
            },
            new Software
            {
                SoftwareId = 3,Name = "Health Tracker",Price = 300, Description = "Health monitoring software", CurrentVersion = "3.3",
                Category = "Health"
            },
            new Software
            {
                SoftwareId = 4, Name = "Retail Manager",Price = 800, Description = "Retail management software", CurrentVersion = "4.5",
                Category = "Retail"
            },
            new Software
            {
                SoftwareId = 5, Name = "Real Estate Pro",Price = 600, Description = "Real estate management software", CurrentVersion = "1.2",
                Category = "Real Estate"
            },
            new Software
            {
                SoftwareId = 6, Name = "Marketing Hub",Price = 150, Description = "Marketing automation software", CurrentVersion = "5.0",
                Category = "Marketing"
            },
            new Software
            {
                SoftwareId = 7, Name = "Project Planner",Price = 900, Description = "Project management software", CurrentVersion = "2.4",
                Category = "Productivity"
            },
            new Software
            {
                SoftwareId = 8, Name = "CRM Boost",Price = 600,Description = "Customer relationship management software", CurrentVersion = "3.6",
                Category = "CRM"
            },
            new Software
            {
                SoftwareId = 9, Name = "HR Connect",Price = 550, Description = "Human resources management software", CurrentVersion = "4.0",
                Category = "HR"
            },
            new Software
            {
                SoftwareId = 10, Name = "Logistics Pro",Price = 1000, Description = "Logistics and supply chain software", CurrentVersion = "1.5",
                Category = "Logistics"
            }
        });
        
        modelBuilder.Entity<Discount>().HasData(new List<Discount>()
        {
            new Discount
            {
               DiscountId = 1,Name = "Black Friday", DiscountType = "Subscription", Value = 10.00m,
                StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 3, 3)
            },
            new Discount
            {
                DiscountId = 2, Name = "Summer Sale", DiscountType = "Purchase", Value = 15.00m, StartDate = new DateTime(2024, 6, 1),
                EndDate = new DateTime(2024, 6, 30)
            },
            new Discount
            {
                DiscountId = 3,Name = "New Year Offer", DiscountType = "Subscription", Value = 5.00m,
                StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 15)
            },
            new Discount
            {
                DiscountId = 4,  Name = "Cyber Monday", DiscountType = "Purchase", Value = 20.00m,
                StartDate = new DateTime(2024, 11, 28), EndDate = new DateTime(2024, 11, 30)
            },
            new Discount
            {
                DiscountId = 5,Name = "Winter Discount", DiscountType = "Subscription", Value = 8.00m,
                StartDate = new DateTime(2024, 12, 1), EndDate = new DateTime(2024, 12, 31)
            },
            new Discount
            {
                DiscountId = 6,Name = "Spring Sale", DiscountType = "Purchase", Value = 12.00m, StartDate = new DateTime(2024, 4, 1),
                EndDate = new DateTime(2024, 4, 30)
            },
            new Discount
            {
                DiscountId = 7,Name = "Autumn Offer", DiscountType = "Subscription", Value = 7.00m,
                StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 9, 30)
            },
            new Discount
            {
                DiscountId = 8,Name = "Holiday Deal", DiscountType = "Purchase", Value = 10.00m,
                StartDate = new DateTime(2024, 12, 15), EndDate = new DateTime(2024, 12, 31)
            },
            new Discount
            {
                DiscountId = 9,Name = "Loyalty Discount", DiscountType = "Purchase", Value = 5.00m,
                StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 12, 31)
            },
            new Discount
            {
                DiscountId = 10,Name = "Exclusive Offer", DiscountType = "Subscription", Value = 25.00m,
                StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2024, 2, 28)
            }
        });
        
        modelBuilder.Entity<Contract>().HasData(new List<Contract>()
        {
            new Contract
            {
               ContractId = 1,CustomerId = 1, SoftwareId = 1, Version = "1.0", StartDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 1, 10), Price = 1000.00m, DiscountId = 1,PriceAfterDiscount = 200.00m, SupportYears = 1,
                IsSigned = false
            },
            new Contract
            {
                ContractId = 2, CustomerId = 2, SoftwareId = 2, Version = "2.1", StartDate = new DateTime(2024, 2, 1),
                EndDate = new DateTime(2024, 2, 15), Price = 2000.00m, DiscountId = 2,PriceAfterDiscount = 1200.00m, SupportYears = 2,
                IsSigned = false
            },
            new Contract
            {
                ContractId = 3, CustomerId = 3, SoftwareId = 3, Version = "3.3", StartDate = new DateTime(2024, 3, 1),
                EndDate = new DateTime(2024, 3, 12), Price = 3000.00m, DiscountId = 3, PriceAfterDiscount = 2000.00m,SupportYears = 3,
                IsSigned = false
            },
            new Contract
            {
                ContractId = 4,  CustomerId = 4, SoftwareId = 4, Version = "4.5", StartDate = new DateTime(2024, 4, 1),
                EndDate = new DateTime(2024, 4, 18), Price = 4000.00m, DiscountId = 4,PriceAfterDiscount = 1900.00m, SupportYears = 1,
                IsSigned = false
            },
            new Contract
            {
                ContractId = 5,  CustomerId = 5, SoftwareId = 5, Version = "1.2", StartDate = new DateTime(2024, 5, 1),
                EndDate = new DateTime(2024, 5, 25), Price = 1500.00m, DiscountId = 5,PriceAfterDiscount = 1200.00m, SupportYears = 2,
                IsSigned = false
            },
            new Contract
            {
                ContractId = 6, CustomerId = 6, SoftwareId = 6, Version = "5.0", StartDate = new DateTime(2024, 6, 1),
                EndDate = new DateTime(2024, 6, 20), Price = 2500.00m, DiscountId = 6,PriceAfterDiscount = 100.00m, SupportYears = 3,
                IsSigned = false
            },
            new Contract
            {
                ContractId = 7, CustomerId = 7, SoftwareId = 7, Version = "2.4", StartDate = new DateTime(2024, 7, 1),
                EndDate = new DateTime(2024, 7, 15), Price = 1200.00m, DiscountId = 7,PriceAfterDiscount = 200.00m, SupportYears = 1,
                IsSigned = false
            },
            new Contract
            {
                ContractId = 8, CustomerId = 8, SoftwareId = 8, Version = "3.6", StartDate = new DateTime(2024, 8, 1),
                EndDate = new DateTime(2024, 8, 10), Price = 2600.00m, DiscountId = 8, PriceAfterDiscount = 2000.00m,SupportYears = 2,
                IsSigned = false
            },
            new Contract
            {
                ContractId = 9, CustomerId = 9, SoftwareId = 9, Version = "4.0", StartDate = new DateTime(2024, 9, 1),
                EndDate = new DateTime(2024, 9, 30), Price = 1800.00m, DiscountId = 9,PriceAfterDiscount = 200.00m, SupportYears = 3,
                IsSigned = false
            },
            new Contract
            {
                ContractId = 10, CustomerId = 10, SoftwareId = 10, Version = "1.5", StartDate = new DateTime(2024, 10, 1),
                EndDate = new DateTime(2024, 10, 12), Price = 2200.00m, DiscountId = 10,PriceAfterDiscount = 1000.00m, SupportYears = 1,
                IsSigned = false
            }
        });
        
        modelBuilder.Entity<Payment>().HasData(new List<Payment>()
        {
            new Payment {PaymentId = 1,ContractId = 1,CustomerId = 1,Amount = 1000.00m, PaymentDate = new DateTime(2024, 1, 5) },
            new Payment {PaymentId = 2,ContractId =2 ,CustomerId = 2, Amount = 2000.00m, PaymentDate = new DateTime(2024, 2, 10) },
            new Payment {PaymentId = 3,ContractId =3 ,CustomerId = 3, Amount = 3000.00m, PaymentDate = new DateTime(2024, 3, 10) },
            new Payment {PaymentId = 4,ContractId =4 ,CustomerId = 4, Amount = 4000.00m, PaymentDate = new DateTime(2024, 4, 10) },
            new Payment {PaymentId = 5,ContractId =5 ,CustomerId = 5, Amount = 1500.00m, PaymentDate = new DateTime(2024, 5, 10) },
            new Payment {PaymentId = 6,ContractId =6 ,CustomerId = 6, Amount = 2500.00m, PaymentDate = new DateTime(2024, 6, 10) },
            new Payment {PaymentId = 7,ContractId =7 ,CustomerId = 7, Amount = 1200.00m, PaymentDate = new DateTime(2024, 7, 10) },
            new Payment {PaymentId = 8,ContractId =8 ,CustomerId = 8, Amount = 2600.00m, PaymentDate = new DateTime(2024, 8, 10) },
            new Payment {PaymentId = 9,ContractId =9 ,CustomerId = 9, Amount = 1800.00m, PaymentDate = new DateTime(2024, 9, 10) },
            new Payment {PaymentId = 10,ContractId =10 ,CustomerId = 10, Amount = 2200.00m, PaymentDate = new DateTime(2024, 10, 10) }
        });
        
        modelBuilder.Entity<Subscription>().HasData(new List<Subscription>()
        {
            new Subscription
            {
               SubscriptionId = 1,CustomerId = 1, SoftwareId = 1, RenewalPeriod = "Monthly", Price = 50.00m,
                StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 31), DiscountId = 1
            },
            new Subscription
            {
                SubscriptionId = 2, CustomerId = 2, SoftwareId = 2, RenewalPeriod = "Yearly", Price = 500.00m,
                StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2025, 1, 31), DiscountId = 2
            },
            new Subscription
            {
                SubscriptionId = 3, CustomerId = 3, SoftwareId = 3, RenewalPeriod = "Monthly", Price = 60.00m,
                StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 3, 31), DiscountId = 3
            },
            new Subscription
            {
                SubscriptionId = 4, CustomerId = 4, SoftwareId = 4, RenewalPeriod = "Yearly", Price = 600.00m,
                StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2025, 3, 31), DiscountId = 4
            },
            new Subscription
            {
                SubscriptionId = 5,  CustomerId = 5, SoftwareId = 5, RenewalPeriod = "Monthly", Price = 70.00m,
                StartDate = new DateTime(2024, 5, 1), EndDate = new DateTime(2024, 5, 31), DiscountId = 5
            },
            new Subscription
            {
                SubscriptionId = 6, CustomerId = 6, SoftwareId = 6, RenewalPeriod = "Yearly", Price = 700.00m,
                StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2025, 5, 31), DiscountId = 6
            },
            new Subscription
            {
                SubscriptionId = 7, CustomerId = 7, SoftwareId = 7, RenewalPeriod = "Monthly", Price = 80.00m,
                StartDate = new DateTime(2024, 7, 1), EndDate = new DateTime(2024, 7, 31), DiscountId = 7
            },
            new Subscription
            {
                SubscriptionId = 8, CustomerId = 8, SoftwareId = 8, RenewalPeriod = "Yearly", Price = 800.00m,
                StartDate = new DateTime(2024, 8, 1), EndDate = new DateTime(2025, 7, 31), DiscountId = 8
            },
            new Subscription
            {
                SubscriptionId = 9, CustomerId = 9, SoftwareId = 9, RenewalPeriod = "Monthly", Price = 90.00m,
                StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 9, 30), DiscountId = 9
            },
            new Subscription
            {
                SubscriptionId = 10, CustomerId = 10, SoftwareId = 10, RenewalPeriod = "Yearly", Price = 900.00m,
                StartDate = new DateTime(2024, 10, 1), EndDate = new DateTime(2025, 9, 30), DiscountId = 10
            }
        });
        
        modelBuilder.Entity<Employee>().HasData(new List<Employee>()
        {
            new Employee {EmployeeId = 1,Login = "employee1", PasswordHash = "hashedpassword1", Role = "Manager" },
            new Employee {EmployeeId = 2, Login = "employee2", PasswordHash = "hashedpassword2", Role = "Support" },
            new Employee {EmployeeId = 3, Login = "employee3", PasswordHash = "hashedpassword3", Role = "Sales" },
            new Employee {EmployeeId = 4, Login = "employee4", PasswordHash = "hashedpassword4", Role = "Developer" },
            new Employee {EmployeeId = 5, Login = "employee5", PasswordHash = "hashedpassword5", Role = "HR" },
            new Employee {EmployeeId = 6, Login = "employee6", PasswordHash = "hashedpassword6", Role = "Admin" },
            new Employee {EmployeeId = 7, Login = "employee7", PasswordHash = "hashedpassword7", Role = "Intern" },
            new Employee {EmployeeId = 8, Login = "employee8", PasswordHash = "hashedpassword8", Role = "Accountant" },
            new Employee {EmployeeId = 9, Login = "employee9", PasswordHash = "hashedpassword9", Role = "Designer" },
            new Employee {EmployeeId = 10, Login = "employee10", PasswordHash = "hashedpassword10", Role = "Marketing" }
        });
    }
}