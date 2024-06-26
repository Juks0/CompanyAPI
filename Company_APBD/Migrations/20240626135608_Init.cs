using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SoftwareId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    PriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupportYears = table.Column<int>(type: "int", nullable: false),
                    IsSigned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KRS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    SoftwareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.SoftwareId);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SoftwareId = table.Column<int>(type: "int", nullable: false),
                    RenewalPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.SubscriptionId);
                });

            migrationBuilder.InsertData(
                table: "Contract",
                columns: new[] { "ContractId", "CustomerId", "DiscountId", "EndDate", "IsSigned", "Price", "PriceAfterDiscount", "SoftwareId", "StartDate", "SupportYears", "Version" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1000.00m, 200.00m, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "1.0" },
                    { 2, 2, 2, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2000.00m, 1200.00m, 2, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "2.1" },
                    { 3, 3, 3, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3000.00m, 2000.00m, 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "3.3" },
                    { 4, 4, 4, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4000.00m, 1900.00m, 4, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "4.5" },
                    { 5, 5, 5, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1500.00m, 1200.00m, 5, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "1.2" },
                    { 6, 6, 6, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2500.00m, 100.00m, 6, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "5.0" },
                    { 7, 7, 7, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1200.00m, 200.00m, 7, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "2.4" },
                    { 8, 8, 8, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2600.00m, 2000.00m, 8, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "3.6" },
                    { 9, 9, 9, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1800.00m, 200.00m, 9, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "4.0" },
                    { 10, 10, 10, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2200.00m, 1000.00m, 10, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "1.5" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CompanyName", "Discriminator", "Email", "KRS", "PhoneNumber" },
                values: new object[,]
                {
                    { 6, "123 Birch St, Warsaw, Poland", "Company 1", "CompanyCustomer", "info@company1.com", "1234567890", "+48678901234" },
                    { 7, "234 Pine St, Krakow, Poland", "Company 2", "CompanyCustomer", "info@company2.com", "2345678901", "+48789012345" },
                    { 8, "345 Oak St, Poznan, Poland", "Company 3", "CompanyCustomer", "info@company3.com", "3456789012", "+48890123456" },
                    { 9, "456 Maple St, Wroclaw, Poland", "Company 4", "CompanyCustomer", "info@company4.com", "4567890123", "+48901234567" },
                    { 10, "567 Willow St, Gdansk, Poland", "Company 5", "CompanyCustomer", "info@company5.com", "5678901234", "+48101234568" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Discriminator", "Email", "FirstName", "LastName", "PESEL", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "707 Willow St, Gdansk, Poland", "IndividualCustomer", "info@company5.com", "John", "Doe", "12345678901", "+48101234568" },
                    { 2, "808 Maple St, Warsaw, Poland", "IndividualCustomer", "jane.smith@example.com", "Jane", "Smith", "23456789012", "+48234567890" },
                    { 3, "909 Oak St, Krakow, Poland", "IndividualCustomer", "alice.johnson@example.com", "Alice", "Johnson", "34567890123", "+48345678901" },
                    { 4, "1010 Pine St, Wroclaw, Poland", "IndividualCustomer", "bob.brown@example.com", "Bob", "Brown", "45678901234", "+48456789012" },
                    { 5, "1111 Cedar St, Poznan, Poland", "IndividualCustomer", "carol.davis@example.com", "Carol", "Davis", "56789012345", "+48567890123" }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "DiscountId", "DiscountType", "EndDate", "Name", "StartDate", "Value" },
                values: new object[,]
                {
                    { 1, "Subscription", new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black Friday", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.00m },
                    { 2, "Purchase", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Sale", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.00m },
                    { 3, "Subscription", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Year Offer", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.00m },
                    { 4, "Purchase", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyber Monday", new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.00m },
                    { 5, "Subscription", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winter Discount", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.00m },
                    { 6, "Purchase", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spring Sale", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.00m },
                    { 7, "Subscription", new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Autumn Offer", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.00m },
                    { 8, "Purchase", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holiday Deal", new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.00m },
                    { 9, "Purchase", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loyalty Discount", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.00m },
                    { 10, "Subscription", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exclusive Offer", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.00m }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Login", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, "employee1", "hashedpassword1", "Manager" },
                    { 2, "employee2", "hashedpassword2", "Support" },
                    { 3, "employee3", "hashedpassword3", "Sales" },
                    { 4, "employee4", "hashedpassword4", "Developer" },
                    { 5, "employee5", "hashedpassword5", "HR" },
                    { 6, "employee6", "hashedpassword6", "Admin" },
                    { 7, "employee7", "hashedpassword7", "Intern" },
                    { 8, "employee8", "hashedpassword8", "Accountant" },
                    { 9, "employee9", "hashedpassword9", "Designer" },
                    { 10, "employee10", "hashedpassword10", "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "Amount", "ContractId", "CustomerId", "PaymentDate" },
                values: new object[,]
                {
                    { 1, 1000.00m, 1, 1, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2000.00m, 2, 2, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "PaymentId", "Amount", "ContractId", "CustomerId", "PaymentDate" },
                values: new object[,]
                {
                    { 3, 3000.00m, 3, 3, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4000.00m, 4, 4, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1500.00m, 5, 5, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2500.00m, 6, 6, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1200.00m, 7, 7, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2600.00m, 8, 8, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1800.00m, 9, 9, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 2200.00m, 10, 10, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Software",
                columns: new[] { "SoftwareId", "Category", "CurrentVersion", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Finance", "1.0", "Financial management software", "Finance Pro", 500m },
                    { 2, "Education", "2.1", "Educational software for schools", "Edu Learn", 100m },
                    { 3, "Health", "3.3", "Health monitoring software", "Health Tracker", 300m },
                    { 4, "Retail", "4.5", "Retail management software", "Retail Manager", 800m },
                    { 5, "Real Estate", "1.2", "Real estate management software", "Real Estate Pro", 600m },
                    { 6, "Marketing", "5.0", "Marketing automation software", "Marketing Hub", 150m },
                    { 7, "Productivity", "2.4", "Project management software", "Project Planner", 900m },
                    { 8, "CRM", "3.6", "Customer relationship management software", "CRM Boost", 600m },
                    { 9, "HR", "4.0", "Human resources management software", "HR Connect", 550m },
                    { 10, "Logistics", "1.5", "Logistics and supply chain software", "Logistics Pro", 1000m }
                });

            migrationBuilder.InsertData(
                table: "Subscription",
                columns: new[] { "SubscriptionId", "CustomerId", "DiscountId", "EndDate", "Price", "RenewalPeriod", "SoftwareId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.00m, "Monthly", 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 500.00m, "Yearly", 2, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.00m, "Monthly", 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 4, new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 600.00m, "Yearly", 4, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 5, new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.00m, "Monthly", 5, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 6, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 700.00m, "Yearly", 6, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 7, new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.00m, "Monthly", 7, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 8, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 800.00m, "Yearly", 8, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, 9, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.00m, "Monthly", 9, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, 10, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 900.00m, "Yearly", 10, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Subscription");
        }
    }
}
