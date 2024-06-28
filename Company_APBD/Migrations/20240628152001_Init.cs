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
                name: "CompanyCustomer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KRS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCustomer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Role_FK_RoleID",
                        column: x => x.FK_RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractCompanyCustmer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discountID = table.Column<int>(type: "int", nullable: false),
                    TotalToPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactLength = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Fk_Software = table.Column<int>(type: "int", nullable: false),
                    CompanyCustomerID = table.Column<int>(type: "int", nullable: false),
                    ContractCompanyCustmerContractID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCompanyCustmer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractCompanyCustmer_CompanyCustomer_CompanyCustomerID",
                        column: x => x.CompanyCustomerID,
                        principalTable: "CompanyCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractCompanyCustmer_ContractCompanyCustmer_ContractCompanyCustmerContractID",
                        column: x => x.ContractCompanyCustmerContractID,
                        principalTable: "ContractCompanyCustmer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ContractCompanyCustmer_Software_Fk_Software",
                        column: x => x.Fk_Software,
                        principalTable: "Software",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractCustomerIndividual",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discountID = table.Column<int>(type: "int", nullable: false),
                    TotalToPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactLength = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Fk_Software = table.Column<int>(type: "int", nullable: false),
                    IndividualCustomerID = table.Column<int>(type: "int", nullable: false),
                    ContractIndividualCustomerContractID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractCustomerIndividual", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContractCustomerIndividual_ContractCustomerIndividual_ContractIndividualCustomerContractID",
                        column: x => x.ContractIndividualCustomerContractID,
                        principalTable: "ContractCustomerIndividual",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ContractCustomerIndividual_IndividualCustomer_IndividualCustomerID",
                        column: x => x.IndividualCustomerID,
                        principalTable: "IndividualCustomer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractCustomerIndividual_Software_Fk_Software",
                        column: x => x.Fk_Software,
                        principalTable: "Software",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompanyCustomer",
                columns: new[] { "CustomerID", "Adress", "CompanyName", "Email", "IsDeleted", "KRS", "PhoneNumber" },
                values: new object[,]
                {
                    { 4, "Krasnalska", "CompanyName1", "Email1", false, "111111111", "PhoneNumber1" },
                    { 5, "Trakt lubelski", "CompanyName2", "Email2", false, "123456789", "PhoneNumber2" },
                    { 6, "grrpowska", "CompanyName3", "Email3", false, "123336722", "PhoneNumber3" }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "ID", "DiscountType", "EndDate", "Name", "StartDate", "Value" },
                values: new object[,]
                {
                    { 1, "Type1", new DateTime(2024, 7, 8, 17, 20, 1, 177, DateTimeKind.Local).AddTicks(9860), "Discount1", new DateTime(2024, 6, 28, 17, 20, 1, 177, DateTimeKind.Local).AddTicks(9830), 0.1m },
                    { 2, "Type2", new DateTime(2024, 7, 8, 17, 20, 1, 177, DateTimeKind.Local).AddTicks(9863), "Discount2", new DateTime(2024, 6, 28, 17, 20, 1, 177, DateTimeKind.Local).AddTicks(9863), 0.2m },
                    { 3, "Type3", new DateTime(2024, 7, 8, 17, 20, 1, 177, DateTimeKind.Local).AddTicks(9866), "Discount3", new DateTime(2024, 6, 28, 17, 20, 1, 177, DateTimeKind.Local).AddTicks(9865), 0.3m }
                });

            migrationBuilder.InsertData(
                table: "IndividualCustomer",
                columns: new[] { "CustomerID", "Adress", "Email", "FirstName", "IsDeleted", "LastName", "PESEL", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Wolecinska", "Email1", "FirstName1", false, "LastName1", "12345678901", "PhoneNumber1" },
                    { 2, "Krasnalska", "Email2", "FirstName2", false, "LastName2", "23345678901", "PhoneNumber2" },
                    { 3, "Krasnalska", "Email3", "FirstName3", false, "LastName3", "22345678901", "PhoneNumber3" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Software",
                columns: new[] { "ID", "Category", "CurrentVersion", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Category1", "1.0", "Description1", "Software1", 100m },
                    { 2, "Category2", "2.0", "Description2", "Software2", 200m },
                    { 3, "Category3", "3.0", "Description3", "Software3", 300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContractCompanyCustmer_CompanyCustomerID",
                table: "ContractCompanyCustmer",
                column: "CompanyCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCompanyCustmer_ContractCompanyCustmerContractID",
                table: "ContractCompanyCustmer",
                column: "ContractCompanyCustmerContractID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCompanyCustmer_Fk_Software",
                table: "ContractCompanyCustmer",
                column: "Fk_Software");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCustomerIndividual_ContractIndividualCustomerContractID",
                table: "ContractCustomerIndividual",
                column: "ContractIndividualCustomerContractID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCustomerIndividual_Fk_Software",
                table: "ContractCustomerIndividual",
                column: "Fk_Software");

            migrationBuilder.CreateIndex(
                name: "IX_ContractCustomerIndividual_IndividualCustomerID",
                table: "ContractCustomerIndividual",
                column: "IndividualCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_FK_RoleID",
                table: "Employee",
                column: "FK_RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractCompanyCustmer");

            migrationBuilder.DropTable(
                name: "ContractCustomerIndividual");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "CompanyCustomer");

            migrationBuilder.DropTable(
                name: "IndividualCustomer");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
