using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingExpAndCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "123 Software Street", "Tech Corp" });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "CompanyId", "EmployeeId", "EndDate", "JobTitle", "StartDate" },
                values: new object[] { 1, 1, null, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Engineer", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
