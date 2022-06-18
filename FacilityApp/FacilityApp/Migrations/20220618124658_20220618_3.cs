using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacilityApp.Migrations
{
    public partial class _20220618_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "TenantFlatDetails");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TenantFlatDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "TenantFlatDetails");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "TenantFlatDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
