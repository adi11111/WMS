using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "TotalOtherDiscount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalClaimAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "TaxPer",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "ServiceDiscountPer",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "RequestedAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "RepairerID",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ReasonInspNotDone",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PayeeID",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ParameterCode",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "OtherDiscountPer",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "OldClaimCode",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LastServiceMileage",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastServiceDate",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "LastBreakdownMileage",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "LabourDiscountPer",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FaxReceivedDate",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "FYCode",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnteredOn",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "DeductableAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfFailure",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CustomerInvoiceReceivedOn",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CustomerInvoiceDate",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyCode",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ConfigID",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClaimFrom",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BranchCode",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorizedBy",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "AuthorizedAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthorisedOn",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "ArigPaidAmountUSD",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualClaimAmount",
                table: "ProcessClaim",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "TotalOtherDiscount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalClaimAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "TaxPer",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "ServiceDiscountPer",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RequestedAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RepairerID",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReasonInspNotDone",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PayeeID",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParameterCode",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "OtherDiscountPer",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OldClaimCode",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastServiceMileage",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastServiceDate",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastBreakdownMileage",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "LabourDiscountPer",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FaxReceivedDate",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FYCode",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "ExchangeRate",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnteredOn",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DeductableAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfFailure",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CustomerInvoiceReceivedOn",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CustomerInvoiceDate",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrencyCode",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConfigID",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClaimFrom",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchCode",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorizedBy",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AuthorizedAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AuthorisedOn",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ArigPaidAmountUSD",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ActualClaimAmount",
                table: "ProcessClaim",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
