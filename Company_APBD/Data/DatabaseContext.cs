using Company_APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_APBD.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CompanyCustomer> CompanyCustomers { get; set; }
    public DbSet<Software> Software { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Customer>()
            .HasDiscriminator<string>("CustomerType")
            .HasValue<IndividualCustomer>("Individual")
            .HasValue<CompanyCustomer>("Company");
        //
        // modelBuilder.Entity<Customer>()
        //     .Property(c => c.CustomerId)
        //     .ValueGeneratedOnAdd();
        // modelBuilder.Entity<Software>()
        //     .Property(s => s.SoftwareId)
        //     .ValueGeneratedOnAdd();
        // modelBuilder.Entity<Discount>()
        //     .Property(d => d.DiscountId)
        //     .ValueGeneratedOnAdd();
        // modelBuilder.Entity<Contract>()
        //     .Property(c => c.ContractId)
        //     .ValueGeneratedOnAdd();
        // modelBuilder.Entity<Payment>()
        //     .Property(p => p.PaymentId)
        //     .ValueGeneratedOnAdd();
        // modelBuilder.Entity<Subscription>()
        //     .Property(s => s.SubscriptionId)
        //     .ValueGeneratedOnAdd();
        // modelBuilder.Entity<Employee>()
        //     .Property(e => e.EmployeeId)
        //     .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
        modelBuilder.Entity<Discount>().HasKey(s => s.DiscountId);
        modelBuilder.Entity<Contract>().HasKey(c => c.ContractId);
        modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
        modelBuilder.Entity<Subscription>().HasKey(s => s.SubscriptionId);

       

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer
            {
                CustomerType = "Individual", Address = "123 Main St, Warsaw, Poland", Email = "john.doe@example.com",
                PhoneNumber = "+48123456789"
            },
            new Customer
            {
                CustomerType = "Individual", Address = "456 Elm St, Krakow, Poland", Email = "jane.smith@example.com",
                PhoneNumber = "+48234567890"
            },
            new Customer
            {
                CustomerType = "Individual", Address = "789 Oak St, Poznan, Poland", Email = "mike.johnson@example.com",
                PhoneNumber = "+48345678901"
            },
            new Customer
            {
                CustomerType = "Individual", Address = "101 Pine St, Wroclaw, Poland", Email = "lisa.brown@example.com",
                PhoneNumber = "+48456789012"
            },
            new Customer
            {
                CustomerType = "Individual", Address = "202 Cedar St, Gdansk, Poland", Email = "paul.davis@example.com",
                PhoneNumber = "+48567890123"
            },
            new Customer
            {
                CustomerType = "Company", Address = "303 Birch St, Warsaw, Poland", Email = "info@company1.com",
                PhoneNumber = "+48678901234"
            },
            new Customer
            {
                CustomerType = "Company", Address = "404 Maple St, Krakow, Poland", Email = "contact@company2.com",
                PhoneNumber = "+48789012345"
            },
            new Customer
            {
                CustomerType = "Company", Address = "505 Redwood St, Poznan, Poland", Email = "support@company3.com",
                PhoneNumber = "+48890123456"
            },
            new Customer
            {
                CustomerType = "Company", Address = "606 Aspen St, Wroclaw, Poland", Email = "sales@company4.com",
                PhoneNumber = "+48901234567"
            },
            new Customer
            {
                CustomerType = "Company", Address = "707 Willow St, Gdansk, Poland", Email = "info@company5.com",
                PhoneNumber = "+48101234568"
            }
        });

        modelBuilder.Entity<IndividualCustomer>().HasData(new List<IndividualCustomer>()
        {
            new IndividualCustomer { CustomerId = 1, FirstName = "John", LastName = "Doe", PESEL = "12345678901" },
            new IndividualCustomer { CustomerId = 2, FirstName = "Jane", LastName = "Smith", PESEL = "23456789012" },
            new IndividualCustomer { CustomerId = 3, FirstName = "Mike", LastName = "Johnson", PESEL = "34567890123" },
            new IndividualCustomer { CustomerId = 4, FirstName = "Lisa", LastName = "Brown", PESEL = "45678901234" },
            new IndividualCustomer { CustomerId = 5, FirstName = "Paul", LastName = "Davis", PESEL = "56789012345" },
        });

        modelBuilder.Entity<Customer>().HasData(new List<Customer>
        {
            new Customer
            {
                CustomerId = 6, CustomerType = "Company", Address = "303 Birch St, Warsaw, Poland",
                Email = "info@company1.com", PhoneNumber = "+48678901234"
            },
            new Customer
            {
                CustomerId = 7, CustomerType = "Company", Address = "404 Maple St, Krakow, Poland",
                Email = "contact@company2.com", PhoneNumber = "+48789012345"
            },
            new Customer
            {
                CustomerId = 8, CustomerType = "Company", Address = "505 Redwood St, Poznan, Poland",
                Email = "support@company3.com", PhoneNumber = "+48890123456"
            },
            new Customer
            {
                CustomerId = 9, CustomerType = "Company", Address = "606 Aspen St, Wroclaw, Poland",
                Email = "sales@company4.com", PhoneNumber = "+48901234567"
            },
            new Customer
            {
                CustomerId = 10, CustomerType = "Company", Address = "707 Willow St, Gdansk, Poland",
                Email = "info@company5.com", PhoneNumber = "+48101234568"
            }
        });
        modelBuilder.Entity<Software>().HasData(new List<Software>()
        {
            new Software
            {
                Name = "Finance Pro", Description = "Financial management software", CurrentVersion = "1.0",
                Category = "Finance"
            },
            new Software
            {
                Name = "Edu Learn", Description = "Educational software for schools", CurrentVersion = "2.1",
                Category = "Education"
            },
            new Software
            {
                Name = "Health Tracker", Description = "Health monitoring software", CurrentVersion = "3.3",
                Category = "Health"
            },
            new Software
            {
                Name = "Retail Manager", Description = "Retail management software", CurrentVersion = "4.5",
                Category = "Retail"
            },
            new Software
            {
                Name = "Real Estate Pro", Description = "Real estate management software", CurrentVersion = "1.2",
                Category = "Real Estate"
            },
            new Software
            {
                Name = "Marketing Hub", Description = "Marketing automation software", CurrentVersion = "5.0",
                Category = "Marketing"
            },
            new Software
            {
                Name = "Project Planner", Description = "Project management software", CurrentVersion = "2.4",
                Category = "Productivity"
            },
            new Software
            {
                Name = "CRM Boost", Description = "Customer relationship management software", CurrentVersion = "3.6",
                Category = "CRM"
            },
            new Software
            {
                Name = "HR Connect", Description = "Human resources management software", CurrentVersion = "4.0",
                Category = "HR"
            },
            new Software
            {
                Name = "Logistics Pro", Description = "Logistics and supply chain software", CurrentVersion = "1.5",
                Category = "Logistics"
            }
        });

        modelBuilder.Entity<Discount>().HasData(new List<Discount>()
        {
            new Discount
            {
                Name = "Black Friday", DiscountType = "Subscription", Value = 10.00m,
                StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 3, 3)
            },
            new Discount
            {
                Name = "Summer Sale", DiscountType = "Purchase", Value = 15.00m, StartDate = new DateTime(2024, 6, 1),
                EndDate = new DateTime(2024, 6, 30)
            },
            new Discount
            {
                Name = "New Year Offer", DiscountType = "Subscription", Value = 5.00m,
                StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 15)
            },
            new Discount
            {
                Name = "Cyber Monday", DiscountType = "Purchase", Value = 20.00m,
                StartDate = new DateTime(2024, 11, 28), EndDate = new DateTime(2024, 11, 30)
            },
            new Discount
            {
                Name = "Winter Discount", DiscountType = "Subscription", Value = 8.00m,
                StartDate = new DateTime(2024, 12, 1), EndDate = new DateTime(2024, 12, 31)
            },
            new Discount
            {
                Name = "Spring Sale", DiscountType = "Purchase", Value = 12.00m, StartDate = new DateTime(2024, 4, 1),
                EndDate = new DateTime(2024, 4, 30)
            },
            new Discount
            {
                Name = "Autumn Offer", DiscountType = "Subscription", Value = 7.00m,
                StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 9, 30)
            },
            new Discount
            {
                Name = "Holiday Deal", DiscountType = "Purchase", Value = 10.00m,
                StartDate = new DateTime(2024, 12, 15), EndDate = new DateTime(2024, 12, 31)
            },
            new Discount
            {
                Name = "Loyalty Discount", DiscountType = "Purchase", Value = 5.00m,
                StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 12, 31)
            },
            new Discount
            {
                Name = "Exclusive Offer", DiscountType = "Subscription", Value = 25.00m,
                StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2024, 2, 28)
            }
        });

        modelBuilder.Entity<Contract>().HasData(new List<Contract>()
        {
            new Contract
            {
                CustomerId = 1, SoftwareId = 1, Version = "1.0", StartDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 1, 10), Price = 1000.00m, DiscountId = 1, SupportYears = 1,
                IsSigned = false
            },
            new Contract
            {
                CustomerId = 2, SoftwareId = 2, Version = "2.1", StartDate = new DateTime(2024, 2, 1),
                EndDate = new DateTime(2024, 2, 15), Price = 2000.00m, DiscountId = 2, SupportYears = 2,
                IsSigned = false
            },
            new Contract
            {
                CustomerId = 3, SoftwareId = 3, Version = "3.3", StartDate = new DateTime(2024, 3, 1),
                EndDate = new DateTime(2024, 3, 12), Price = 3000.00m, DiscountId = 3, SupportYears = 3,
                IsSigned = false
            },
            new Contract
            {
                CustomerId = 4, SoftwareId = 4, Version = "4.5", StartDate = new DateTime(2024, 4, 1),
                EndDate = new DateTime(2024, 4, 18), Price = 4000.00m, DiscountId = 4, SupportYears = 1,
                IsSigned = false
            },
            new Contract
            {
                CustomerId = 5, SoftwareId = 5, Version = "1.2", StartDate = new DateTime(2024, 5, 1),
                EndDate = new DateTime(2024, 5, 25), Price = 1500.00m, DiscountId = 5, SupportYears = 2,
                IsSigned = false
            },
            new Contract
            {
                CustomerId = 6, SoftwareId = 6, Version = "5.0", StartDate = new DateTime(2024, 6, 1),
                EndDate = new DateTime(2024, 6, 20), Price = 2500.00m, DiscountId = 6, SupportYears = 3,
                IsSigned = false
            },
            new Contract
            {
                CustomerId = 7, SoftwareId = 7, Version = "2.4", StartDate = new DateTime(2024, 7, 1),
                EndDate = new DateTime(2024, 7, 15), Price = 1200.00m, DiscountId = 7, SupportYears = 1,
                IsSigned = false
            },
            new Contract
            {
                CustomerId = 8, SoftwareId = 8, Version = "3.6", StartDate = new DateTime(2024, 8, 1),
                EndDate = new DateTime(2024, 8, 10), Price = 2600.00m, DiscountId = 8, SupportYears = 2,
                IsSigned = false
            },
            new Contract
            {
                CustomerId = 9, SoftwareId = 9, Version = "4.0", StartDate = new DateTime(2024, 9, 1),
                EndDate = new DateTime(2024, 9, 30), Price = 1800.00m, DiscountId = 9, SupportYears = 3,
                IsSigned = false
            },
            new Contract
            {
                CustomerId = 10, SoftwareId = 10, Version = "1.5", StartDate = new DateTime(2024, 10, 1),
                EndDate = new DateTime(2024, 10, 12), Price = 2200.00m, DiscountId = 10, SupportYears = 1,
                IsSigned = false
            }
        });

        modelBuilder.Entity<Payment>().HasData(new List<Payment>()
        {
            new Payment { Amount = 1000.00m, PaymentDate = new DateTime(2024, 1, 5) },
            new Payment { Amount = 2000.00m, PaymentDate = new DateTime(2024, 2, 10) },
            new Payment { Amount = 3000.00m, PaymentDate = new DateTime(2024, 3, 10) },
            new Payment { Amount = 4000.00m, PaymentDate = new DateTime(2024, 4, 10) },
            new Payment { Amount = 1500.00m, PaymentDate = new DateTime(2024, 5, 10) },
            new Payment { Amount = 2500.00m, PaymentDate = new DateTime(2024, 6, 10) },
            new Payment { Amount = 1200.00m, PaymentDate = new DateTime(2024, 7, 10) },
            new Payment { Amount = 2600.00m, PaymentDate = new DateTime(2024, 8, 10) },
            new Payment { Amount = 1800.00m, PaymentDate = new DateTime(2024, 9, 10) },
            new Payment { Amount = 2200.00m, PaymentDate = new DateTime(2024, 10, 10) }
        });

        modelBuilder.Entity<Subscription>().HasData(new List<Subscription>()
        {
            new Subscription
            {
                CustomerId = 1, SoftwareId = 1, RenewalPeriod = "Monthly", Price = 50.00m,
                StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 31), DiscountId = 1
            },
            new Subscription
            {
                CustomerId = 2, SoftwareId = 2, RenewalPeriod = "Yearly", Price = 500.00m,
                StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2025, 1, 31), DiscountId = 2
            },
            new Subscription
            {
                CustomerId = 3, SoftwareId = 3, RenewalPeriod = "Monthly", Price = 60.00m,
                StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 3, 31), DiscountId = 3
            },
            new Subscription
            {
                CustomerId = 4, SoftwareId = 4, RenewalPeriod = "Yearly", Price = 600.00m,
                StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2025, 3, 31), DiscountId = 4
            },
            new Subscription
            {
                CustomerId = 5, SoftwareId = 5, RenewalPeriod = "Monthly", Price = 70.00m,
                StartDate = new DateTime(2024, 5, 1), EndDate = new DateTime(2024, 5, 31), DiscountId = 5
            },
            new Subscription
            {
                CustomerId = 6, SoftwareId = 6, RenewalPeriod = "Yearly", Price = 700.00m,
                StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2025, 5, 31), DiscountId = 6
            },
            new Subscription
            {
                CustomerId = 7, SoftwareId = 7, RenewalPeriod = "Monthly", Price = 80.00m,
                StartDate = new DateTime(2024, 7, 1), EndDate = new DateTime(2024, 7, 31), DiscountId = 7
            },
            new Subscription
            {
                CustomerId = 8, SoftwareId = 8, RenewalPeriod = "Yearly", Price = 800.00m,
                StartDate = new DateTime(2024, 8, 1), EndDate = new DateTime(2025, 7, 31), DiscountId = 8
            },
            new Subscription
            {
                CustomerId = 9, SoftwareId = 9, RenewalPeriod = "Monthly", Price = 90.00m,
                StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 9, 30), DiscountId = 9
            },
            new Subscription
            {
                CustomerId = 10, SoftwareId = 10, RenewalPeriod = "Yearly", Price = 900.00m,
                StartDate = new DateTime(2024, 10, 1), EndDate = new DateTime(2025, 9, 30), DiscountId = 10
            }
        });

        modelBuilder.Entity<Employee>().HasData(new List<Employee>()
        {
            new Employee { Login = "employee1", PasswordHash = "hashedpassword1", Role = "Manager" },
            new Employee { Login = "employee2", PasswordHash = "hashedpassword2", Role = "Support" },
            new Employee { Login = "employee3", PasswordHash = "hashedpassword3", Role = "Sales" },
            new Employee { Login = "employee4", PasswordHash = "hashedpassword4", Role = "Developer" },
            new Employee { Login = "employee5", PasswordHash = "hashedpassword5", Role = "HR" },
            new Employee { Login = "employee6", PasswordHash = "hashedpassword6", Role = "Admin" },
            new Employee { Login = "employee7", PasswordHash = "hashedpassword7", Role = "Intern" },
            new Employee { Login = "employee8", PasswordHash = "hashedpassword8", Role = "Accountant" },
            new Employee { Login = "employee9", PasswordHash = "hashedpassword9", Role = "Designer" },
            new Employee { Login = "employee10", PasswordHash = "hashedpassword10", Role = "Marketing" }
        });
    }
}