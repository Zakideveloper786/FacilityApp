using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacilityApp.Migrations
{
    public partial class _20220611 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "UserRole",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserRole");
        }
    }
}
