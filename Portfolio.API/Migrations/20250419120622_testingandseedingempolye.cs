using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.API.Migrations
{
    /// <inheritdoc />
    public partial class testingandseedingempolye : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2664850e-b6aa-40c1-8db7-6529d523a494");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "82b90487-e1ff-4054-9fb7-46c766a48dcf", 0, "01f4c325-8ad0-4262-9a39-8ba021808649", "Employee", null, false, false, null, "John Doe", null, null, null, null, false, "a11db420-4dfe-4d03-9d1b-0bbc1dbb5b22", false, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82b90487-e1ff-4054-9fb7-46c766a48dcf");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2664850e-b6aa-40c1-8db7-6529d523a494", 0, "392e6696-550e-44a7-87a3-918a4c114599", "Employee", null, false, false, null, "John Doe", null, null, null, null, false, "fdae88c2-9002-47da-aa6b-b20fe39b34c6", false, null });
        }
    }
}
