using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CC",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CCRange",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Capacity",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CapacityRange",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Policy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Policy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "CurrentMileage",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Policy",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PlateType",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegDate",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegNumber",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Policy",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Policy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Policy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "CC",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "CCRange",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "CapacityRange",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "CurrentMileage",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "PlateType",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "RegDate",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "RegNumber",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Policy");
        }
    }
}
