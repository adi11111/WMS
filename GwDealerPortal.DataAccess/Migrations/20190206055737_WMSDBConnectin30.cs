using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnectin30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefNumber",
                table: "Policy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "RefNumber",
                table: "Policy");
        }
    }
}
