using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeBonusManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "Int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "Int32");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "Int32",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "Int");
        }
    }
}
