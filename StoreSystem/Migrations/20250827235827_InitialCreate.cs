using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "Price", "Stock" },
                values: new object[] { 1, new DateTime(2025, 8, 27, 23, 58, 27, 15, DateTimeKind.Utc).AddTicks(2020), "Powerful portable computer", "Laptop", 1200.00m, 50 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "Price", "Stock" },
                values: new object[] { 2, new DateTime(2025, 8, 27, 23, 58, 27, 15, DateTimeKind.Utc).AddTicks(2630), "Wireless ergonomic mouse", "Mouse", 25.00m, 200 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "Name", "Price", "Stock" },
                values: new object[] { 3, new DateTime(2025, 8, 27, 23, 58, 27, 15, DateTimeKind.Utc).AddTicks(2630), "Mechanical RGB keyboard", "Keyboard", 75.00m, 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
