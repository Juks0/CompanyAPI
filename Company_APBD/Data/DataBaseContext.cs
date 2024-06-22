using Company_APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_APBD.Data;
   public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

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

            // Configure relationships and constraints
            modelBuilder.Entity<IndividualCustomer>()
                .HasKey(ic => ic.CustomerID);

            modelBuilder.Entity<IndividualCustomer>()
                .HasOne(ic => ic.Customer)
                .WithOne()
                .HasForeignKey<IndividualCustomer>(ic => ic.CustomerID);

            modelBuilder.Entity<CompanyCustomer>()
                .HasKey(cc => cc.CustomerID);

            modelBuilder.Entity<CompanyCustomer>()
                .HasOne(cc => cc.Customer)
                .WithOne()
                .HasForeignKey<CompanyCustomer>(cc => cc.CustomerID);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerID);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Software)
                .WithMany()
                .HasForeignKey(c => c.SoftwareId);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Discount)
                .WithMany()
                .HasForeignKey(c => c.DiscountID);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Customer)
                .WithMany()
                .HasForeignKey(p => p.CustomerID);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Contract)
                .WithMany()
                .HasForeignKey(p => p.ContractID);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerID);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Software)
                .WithMany()
                .HasForeignKey(s => s.SoftwareID);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Discount)
                .WithMany()
                .HasForeignKey(s => s.DiscountID);

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, CustomerType = "Individual", Address = "123 Main St, Warsaw, Poland", Email = "john.doe@example.com", PhoneNumber = "+48123456789" },
                new Customer { CustomerID = 2, CustomerType = "Individual", Address = "456 Elm St, Krakow, Poland", Email = "jane.smith@example.com", PhoneNumber = "+48234567890" },
                new Customer { CustomerID = 3, CustomerType = "Individual", Address = "789 Oak St, Poznan, Poland", Email = "mike.johnson@example.com", PhoneNumber = "+48345678901" },
                new Customer { CustomerID = 4, CustomerType = "Individual", Address = "101 Pine St, Wroclaw, Poland", Email = "lisa.brown@example.com", PhoneNumber = "+48456789012" },
                new Customer { CustomerID = 5, CustomerType = "Individual", Address = "202 Cedar St, Gdansk, Poland", Email = "paul.davis@example.com", PhoneNumber = "+48567890123" },
                new Customer { CustomerID = 6, CustomerType = "Company", Address = "303 Birch St, Warsaw, Poland", Email = "info@company1.com", PhoneNumber = "+48678901234" },
                new Customer { CustomerID = 7, CustomerType = "Company", Address = "404 Maple St, Krakow, Poland", Email = "contact@company2.com", PhoneNumber = "+48789012345" },
                new Customer { CustomerID = 8, CustomerType = "Company", Address = "505 Redwood St, Poznan, Poland", Email = "support@company3.com", PhoneNumber = "+48890123456" },
                new Customer { CustomerID = 9, CustomerType = "Company", Address = "606 Aspen St, Wroclaw, Poland", Email = "sales@company4.com", PhoneNumber = "+48901234567" },
                new Customer { CustomerID = 10, CustomerType = "Company", Address = "707 Willow St, Gdansk, Poland", Email = "info@company5.com", PhoneNumber = "+48101234568" }
            );

            modelBuilder.Entity<IndividualCustomer>().HasData(
                new IndividualCustomer { CustomerID = 1, FirstName = "John", LastName = "Doe", PESEL = "12345678901" },
                new IndividualCustomer { CustomerID = 2, FirstName = "Jane", LastName = "Smith", PESEL = "23456789012" },
                new IndividualCustomer { CustomerID = 3, FirstName = "Mike", LastName = "Johnson", PESEL = "34567890123" },
                new IndividualCustomer { CustomerID = 4, FirstName = "Lisa", LastName = "Brown", PESEL = "45678901234" },
                new IndividualCustomer { CustomerID = 5, FirstName = "Paul", LastName = "Davis", PESEL = "56789012345" },
                new IndividualCustomer { CustomerID = 6, FirstName = "Nancy", LastName = "Wilson", PESEL = "67890123456" },
                new IndividualCustomer { CustomerID = 7, FirstName = "David", LastName = "Martinez", PESEL = "78901234567" },
                new IndividualCustomer { CustomerID = 8, FirstName = "Susan", LastName = "Anderson", PESEL = "89012345678" },
                new IndividualCustomer { CustomerID = 9, FirstName = "Kevin", LastName = "Taylor", PESEL = "90123456789" },
                new IndividualCustomer { CustomerID = 10, FirstName = "Laura", LastName = "Lee", PESEL = "01234567890" }
            );

            modelBuilder.Entity<CompanyCustomer>().HasData(
                new CompanyCustomer { CustomerID = 11, CompanyName = "Company 1", KRS = "1111111111" },
                new CompanyCustomer { CustomerID = 12, CompanyName = "Company 2", KRS = "2222222222" },
                new CompanyCustomer { CustomerID = 13, CompanyName = "Company 3", KRS = "3333333333" },
                new CompanyCustomer { CustomerID = 14, CompanyName = "Company 4", KRS = "4444444444" },
                new CompanyCustomer { CustomerID = 15, CompanyName = "Company 5", KRS = "5555555555" },
                new CompanyCustomer { CustomerID = 16, CompanyName = "Company 6", KRS = "6666666666" },
                new CompanyCustomer { CustomerID = 17, CompanyName = "Company 7", KRS = "7777777777" },
                new CompanyCustomer { CustomerID = 18, CompanyName = "Company 8", KRS = "8888888888" },
                new CompanyCustomer { CustomerID = 19, CompanyName = "Company 9", KRS = "9999999999" },
                new CompanyCustomer { CustomerID = 20, CompanyName = "Company 10", KRS = "0000000000" }
            );

            modelBuilder.Entity<Software>().HasData(
                new Software { SoftwareID = 1, Name = "Finance Pro", Description = "Financial management software", CurrentVersion = "1.0", Category = "Finance" },
                new Software { SoftwareID = 2, Name = "Edu Learn", Description = "Educational software for schools", CurrentVersion = "2.1", Category = "Education" },
                new Software { SoftwareID = 3, Name = "Health Tracker", Description = "Health monitoring software", CurrentVersion = "3.3", Category = "Health" },
                new Software { SoftwareID = 4, Name = "Retail Manager", Description = "Retail management software", CurrentVersion = "4.5", Category = "Retail" },
                new Software { SoftwareID = 5, Name = "Real Estate Pro", Description = "Real estate management software", CurrentVersion = "1.2", Category = "Real Estate" },
                new Software { SoftwareID = 6, Name = "Marketing Hub", Description = "Marketing automation software", CurrentVersion = "5.0", Category = "Marketing" },
                new Software { SoftwareID = 7, Name = "Project Planner", Description = "Project management software", CurrentVersion = "2.4", Category = "Productivity" },
                new Software { SoftwareID = 8, Name = "CRM Boost", Description = "Customer relationship management software", CurrentVersion = "3.6", Category = "CRM" },
                new Software { SoftwareID = 9, Name = "HR Connect", Description = "Human resources management software", CurrentVersion = "4.0", Category = "HR" },
                new Software { SoftwareID = 10, Name = "Logistics Pro", Description = "Logistics and supply chain software", CurrentVersion = "1.5", Category = "Logistics" }
            );

            modelBuilder.Entity<Discount>().HasData(
                new Discount { DiscountID = 1, Name = "Black Friday", DiscountType = "Subscription", Value = 10.00m, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 3, 3) },
                new Discount { DiscountID = 2, Name = "Summer Sale", DiscountType = "Purchase", Value = 15.00m, StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2024, 6, 30) },
                new Discount { DiscountID = 3, Name = "New Year Offer", DiscountType = "Subscription", Value = 5.00m, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 15) },
                new Discount { DiscountID = 4, Name = "Cyber Monday", DiscountType = "Purchase", Value = 20.00m, StartDate = new DateTime(2024, 11, 28), EndDate = new DateTime(2024, 11, 30) },
                new Discount { DiscountID = 5, Name = "Winter Discount", DiscountType = "Subscription", Value = 8.00m, StartDate = new DateTime(2024, 12, 1), EndDate = new DateTime(2024, 12, 31) },
                new Discount { DiscountID = 6, Name = "Spring Sale", DiscountType = "Purchase", Value = 12.00m, StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2024, 4, 30) },
                new Discount { DiscountID = 7, Name = "Autumn Offer", DiscountType = "Subscription", Value = 7.00m, StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 9, 30) },
                new Discount { DiscountID = 8, Name = "Holiday Deal", DiscountType = "Purchase", Value = 10.00m, StartDate = new DateTime(2024, 12, 15), EndDate = new DateTime(2024, 12, 31) },
                new Discount { DiscountID = 9, Name = "Loyalty Discount", DiscountType = "Purchase", Value = 5.00m, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 12, 31) },
                new Discount { DiscountID = 10, Name = "Exclusive Offer", DiscountType = "Subscription", Value = 25.00m, StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2024, 2, 28) }
            );

            modelBuilder.Entity<Contract>().HasData(
                new Contract { ContractID = 61, CustomerID = 1, SoftwareID = 1, Version = "1.0", StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 10), Price = 1000.00m, DiscountID = 1, SupportYears = 1, IsSigned = false },
                new Contract { ContractID = 62, CustomerID = 2, SoftwareID = 2, Version = "2.1", StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2024, 2, 15), Price = 2000.00m, DiscountID = 2, SupportYears = 2, IsSigned = false },
                new Contract { ContractID = 63, CustomerID = 3, SoftwareID = 3, Version = "3.3", StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 3, 12), Price = 3000.00m, DiscountID = 3, SupportYears = 3, IsSigned = false },
                new Contract { ContractID = 64, CustomerID = 4, SoftwareID = 4, Version = "4.5", StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2024, 4, 18), Price = 4000.00m, DiscountID = 4, SupportYears = 1, IsSigned = false },
                new Contract { ContractID = 65, CustomerID = 5, SoftwareID = 5, Version = "1.2", StartDate = new DateTime(2024, 5, 1), EndDate = new DateTime(2024, 5, 25), Price = 1500.00m, DiscountID = 5, SupportYears = 2, IsSigned = false },
                new Contract { ContractID = 66, CustomerID = 6, SoftwareID = 6, Version = "5.0", StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2024, 6, 20), Price = 2500.00m, DiscountID = 6, SupportYears = 3, IsSigned = false },
                new Contract { ContractID = 67, CustomerID = 7, SoftwareID = 7, Version = "2.4", StartDate = new DateTime(2024, 7, 1), EndDate = new DateTime(2024, 7, 15), Price = 1200.00m, DiscountID = 7, SupportYears = 1, IsSigned = false },
                new Contract { ContractID = 68, CustomerID = 8, SoftwareID = 8, Version = "3.6", StartDate = new DateTime(2024, 8, 1), EndDate = new DateTime(2024, 8, 10), Price = 2600.00m, DiscountID = 8, SupportYears = 2, IsSigned = false },
                new Contract { ContractID = 69, CustomerID = 9, SoftwareID = 9, Version = "4.0", StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 9, 30), Price = 1800.00m, DiscountID = 9, SupportYears = 3, IsSigned = false },
                new Contract { ContractID = 70, CustomerID = 10, SoftwareID = 10, Version = "1.5", StartDate = new DateTime(2024, 10, 1), EndDate = new DateTime(2024, 10, 12), Price = 2200.00m, DiscountID = 10, SupportYears = 1, IsSigned = false }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment { PaymentID = 61, ContractID = 61, CustomerID = 1, Amount = 1000.00m, PaymentDate = new DateTime(2024, 1, 5) },
                new Payment { PaymentID = 62, ContractID = 62, CustomerID = 2, Amount = 2000.00m, PaymentDate = new DateTime(2024, 2, 10) },
                new Payment { PaymentID = 63, ContractID = 63, CustomerID = 3, Amount = 3000.00m, PaymentDate = new DateTime(2024, 3, 10) },
                new Payment { PaymentID = 64, ContractID = 64, CustomerID = 4, Amount = 4000.00m, PaymentDate = new DateTime(2024, 4, 10) },
                new Payment { PaymentID = 65, ContractID = 65, CustomerID = 5, Amount = 1500.00m, PaymentDate = new DateTime(2024, 5, 10) },
                new Payment { PaymentID = 66, ContractID = 66, CustomerID = 6, Amount = 2500.00m, PaymentDate = new DateTime(2024, 6, 10) },
                new Payment { PaymentID = 67, ContractID = 67, CustomerID = 7, Amount = 1200.00m, PaymentDate = new DateTime(2024, 7, 10) },
                new Payment { PaymentID = 68, ContractID = 68, CustomerID = 8, Amount = 2600.00m, PaymentDate = new DateTime(2024, 8, 10) },
                new Payment { PaymentID = 69, ContractID = 69, CustomerID = 9, Amount = 1800.00m, PaymentDate = new DateTime(2024, 9, 10) },
                new Payment { PaymentID = 70, ContractID = 70, CustomerID = 10, Amount = 2200.00m, PaymentDate = new DateTime(2024, 10, 10) }
            );

            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionID = 1, CustomerID = 1, SoftwareID = 1, RenewalPeriod = "Monthly", Price = 50.00m, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 1, 31), DiscountID = 1 },
                new Subscription { SubscriptionID = 2, CustomerID = 2, SoftwareID = 2, RenewalPeriod = "Yearly", Price = 500.00m, StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2025, 1, 31), DiscountID = 2 },
                new Subscription { SubscriptionID = 3, CustomerID = 3, SoftwareID = 3, RenewalPeriod = "Monthly", Price = 60.00m, StartDate = new DateTime(2024, 3, 1), EndDate = new DateTime(2024, 3, 31), DiscountID = 3 },
                new Subscription { SubscriptionID = 4, CustomerID = 4, SoftwareID = 4, RenewalPeriod = "Yearly", Price = 600.00m, StartDate = new DateTime(2024, 4, 1), EndDate = new DateTime(2025, 3, 31), DiscountID = 4 },
                new Subscription { SubscriptionID = 5, CustomerID = 5, SoftwareID = 5, RenewalPeriod = "Monthly", Price = 70.00m, StartDate = new DateTime(2024, 5, 1), EndDate = new DateTime(2024, 5, 31), DiscountID = 5 },
                new Subscription { SubscriptionID = 6, CustomerID = 6, SoftwareID = 6, RenewalPeriod = "Yearly", Price = 700.00m, StartDate = new DateTime(2024, 6, 1), EndDate = new DateTime(2025, 5, 31), DiscountID = 6 },
                new Subscription { SubscriptionID = 7, CustomerID = 7, SoftwareID = 7, RenewalPeriod = "Monthly", Price = 80.00m, StartDate = new DateTime(2024, 7, 1), EndDate = new DateTime(2024, 7, 31), DiscountID = 7 },
                new Subscription { SubscriptionID = 8, CustomerID = 8, SoftwareID = 8, RenewalPeriod = "Yearly", Price = 800.00m, StartDate = new DateTime(2024, 8, 1), EndDate = new DateTime(2025, 7, 31), DiscountID = 8 },
                new Subscription { SubscriptionID = 9, CustomerID = 9, SoftwareID = 9, RenewalPeriod = "Monthly", Price = 90.00m, StartDate = new DateTime(2024, 9, 1), EndDate = new DateTime(2024, 9, 30), DiscountID = 9 },
                new Subscription { SubscriptionID = 10, CustomerID = 10, SoftwareID = 10, RenewalPeriod = "Yearly", Price = 900.00m, StartDate = new DateTime(2024, 10, 1), EndDate = new DateTime(2025, 9, 30), DiscountID = 10 }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, Login = "employee1", PasswordHash = "hashedpassword1", Role = "Manager" },
                new Employee { EmployeeID = 2, Login = "employee2", PasswordHash = "hashedpassword2", Role = "Support" },
                new Employee { EmployeeID = 3, Login = "employee3", PasswordHash = "hashedpassword3", Role = "Sales" },
                new Employee { EmployeeID = 4, Login = "employee4", PasswordHash = "hashedpassword4", Role = "Developer" },
                new Employee { EmployeeID = 5, Login = "employee5", PasswordHash = "hashedpassword5", Role = "HR" },
                new Employee { EmployeeID = 6, Login = "employee6", PasswordHash = "hashedpassword6", Role = "Admin" },
                new Employee { EmployeeID = 7, Login = "employee7", PasswordHash = "hashedpassword7", Role = "Intern" },
                new Employee { EmployeeID = 8, Login = "employee8", PasswordHash = "hashedpassword8", Role = "Accountant" },
                new Employee { EmployeeID = 9, Login = "employee9", PasswordHash = "hashedpassword9", Role = "Designer" },
                new Employee { EmployeeID = 10, Login = "employee10", PasswordHash = "hashedpassword10", Role = "Marketing" }
            );
        }
    }
}