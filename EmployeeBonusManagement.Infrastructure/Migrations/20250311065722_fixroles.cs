using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeBonusManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4be578f6-9946-4b97-a55c-a2da3a90630d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccc4f50a-3938-42d5-8561-2378e8e47595");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "B2A0E6F1-1E30-4D4B-97E1-5B3F0A5D6A10", null, "Admin", "ADMIN" },
                    { "D3C1F7A2-2F41-5E5C-88F2-6C4G1B6E7B21", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B2A0E6F1-1E30-4D4B-97E1-5B3F0A5D6A10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D3C1F7A2-2F41-5E5C-88F2-6C4G1B6E7B21");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4be578f6-9946-4b97-a55c-a2da3a90630d", null, "Admin", "ADMIN" },
                    { "ccc4f50a-3938-42d5-8561-2378e8e47595", null, "User", "USER" }
                });
        }
    }
}
