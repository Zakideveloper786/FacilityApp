using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacilityApp.Migrations
{
    public partial class _20220618_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "Tenant");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Tenant");

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

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "TenantFlatDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

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

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "TenantFlatDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<bool>(
                name: "ParkingKeyProvided",
                table: "TenantFlatDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ParkingSlotFloor",
                table: "TenantFlatDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParkingSlotNo",
                table: "TenantFlatDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "RentAmount",
                table: "TenantFlatDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SEWANo",
                table: "TenantFlatDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SEWAStatusId",
                table: "TenantFlatDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "TenantFlatDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "TenantFlatDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TenantFlatDetails",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToPay",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "FrequencyId",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "MaintananceCost",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "ParkingAmount",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "ParkingKeyProvided",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "ParkingSlotFloor",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "ParkingSlotNo",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "RentAmount",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "SEWANo",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "SEWAStatusId",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TenantFlatDetails");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TenantFlatDetails");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TenantFlatDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToPay",
                table: "Tenant",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Tenant",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
