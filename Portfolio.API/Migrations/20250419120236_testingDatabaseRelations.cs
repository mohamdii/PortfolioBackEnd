using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.API.Migrations
{
    /// <inheritdoc />
    public partial class testingDatabaseRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmployeeId", "EmployeeId1" },
                values: new object[] { 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_EmployeeId1",
                table: "Companies",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_EmployeeId1",
                table: "Companies",
                column: "EmployeeId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_EmployeeId1",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_EmployeeId1",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Companies");
        }
    }
}
