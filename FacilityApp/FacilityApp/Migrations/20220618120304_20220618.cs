using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacilityApp.Migrations
{
    public partial class _20220618 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "MaintananceCost",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "ParkingAmount",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "RentAmount",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Building");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "TenantFlatDetails",
                newName: "TenancyStartDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "TenantFlatDetails",
                newName: "TenancyEndDate");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "TenantFlatDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isFacilityApp",
                table: "TenantFlatDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ChequeNo",
                table: "Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlatId",
                table: "Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlatTypeId",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsParking",
                table: "Tenant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MaintananceCost",
                table: "Tenant",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NotificationSent",
                table: "Tenant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ParkingAmount",
                table: "Tenant",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ParkingKeyProvided",
                table: "Tenant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ParkingSlotFloor",
                table: "Tenant",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParkingSlotNo",
                table: "Tenant",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "PaymentClearence",
                table: "Tenant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Tenant",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Reminders",
                table: "Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RenewalDate",
                table: "Tenant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RentAmount",
                table: "Tenant",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEWANo",
                table: "Tenant",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SEWAStatusId",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TenancyEndDate",
                table: "Tenant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TenancyStartDate",
                table: "Tenant",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Tenant",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalYears",
                table: "Tenant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isFacilityApp",
                table: "Tenant",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "BuildingId",
                table: "Lead",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "VistingPurposeId",
                table: "Lead",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Building",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VisitingPurpose",
                columns: table => new
                {
                    VisitingPurposeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitingPurpose", x => x.VisitingPurposeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitingPurpose");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "isFacilityApp",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "ChequeNo",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "FlatId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "FlatTypeId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "IsParking",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "MaintananceCost",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "NotificationSent",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ParkingAmount",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ParkingKeyProvided",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ParkingSlotFloor",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "ParkingSlotNo",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "PaymentClearence",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "Reminders",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "RenewalDate",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "RentAmount",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "SEWANo",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "SEWAStatusId",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "TenancyEndDate",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "TenancyStartDate",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "TotalYears",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "isFacilityApp",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "VistingPurposeId",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Building");

            migrationBuilder.RenameColumn(
                name: "TenancyStartDate",
                table: "TenantFlatDetails",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "TenancyEndDate",
                table: "TenantFlatDetails",
                newName: "EndDate");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToPay",
                table: "TenantFlatDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FrequencyId",
                table: "TenantFlatDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaintananceCost",
                table: "TenantFlatDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ParkingAmount",
                table: "TenantFlatDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RentAmount",
                table: "TenantFlatDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "TenantFlatDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuildingId",
                table: "Lead",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "Lead",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Building",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
