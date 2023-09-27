using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace invoice_api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillingStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StatusName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    SubscripsionPeriod = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    BillingStatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BillingStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Paid" },
                    { 3, "Overdue" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Email", "Name", "SubscripsionPeriod", "Surname" },
                values: new object[,]
                {
                    { 1, "New York, USA", "jdow@gmail.com", "John", 2, "Dow" },
                    { 2, "Tel Aviv, Israel", "iisraeli@gmail.com", "Israel", 3, "Israeli" },
                    { 3, "Saint Petersburg, Russian Federation", "vpupkin@mail.ru", "Vasiliy", 1, "Pupkin" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "BillingStatusId", "CreateDate", "CustomerId", "Description" },
                values: new object[,]
                {
                    { 1, 100m, 2, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Tools" },
                    { 2, 1000m, 2, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Software" },
                    { 3, 300m, 2, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Toys" },
                    { 4, 800m, 1, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Vinille music disks" },
                    { 5, 150m, 3, new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Vitamins" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingStatuses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
