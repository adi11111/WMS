using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalClaimAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RequestedAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeductableAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ArigPaidAmountUSD",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualClaimAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AuthorisedOn",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "AuthorizedAmount",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AuthorizedBy",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "ProcessClaim",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "ProcessClaim",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EnteredOn",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GwAuthNo",
                table: "ProcessClaim",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMfgAssistance",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobCardNo",
                table: "ProcessClaim",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastBreakdownMileage",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastServiceMileage",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorisedOn",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "AuthorizedAmount",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "AuthorizedBy",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "EnteredOn",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "GwAuthNo",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "IsMfgAssistance",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "JobCardNo",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "LastBreakdownMileage",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "LastServiceMileage",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "ProcessClaim");

            migrationBuilder.AlterColumn<string>(
                name: "TotalClaimAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "RequestedAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "DeductableAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "ArigPaidAmountUSD",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "ActualClaimAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}
