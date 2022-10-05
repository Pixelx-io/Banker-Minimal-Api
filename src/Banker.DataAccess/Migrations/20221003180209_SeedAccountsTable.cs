using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Banker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedAccountsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Balance", "CreatedDate", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 955.5m, new DateTime(2022, 10, 3, 21, 2, 9, 302, DateTimeKind.Local).AddTicks(7433), "steve_wanderson@gmail.com", "Steve Wanderson" },
                    { 2, 6584.5m, new DateTime(2022, 10, 3, 21, 2, 9, 302, DateTimeKind.Local).AddTicks(7446), "marry-1992@outlook.com", "Marry Dave" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
