using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClaimDate",
                table: "ProcessClaim",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimDate",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProcessClaim");
        }
    }
}
