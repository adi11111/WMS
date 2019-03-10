using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimServiceDetail");

            migrationBuilder.AddColumn<string>(
                name: "LastClaimDetails",
                table: "ProcessClaim",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastServiceDetails",
                table: "ProcessClaim",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParameterCode",
                table: "ProcessClaim",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ParameterValue",
                table: "ProcessClaim",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastClaimDetails",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "LastServiceDetails",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "ParameterCode",
                table: "ProcessClaim");

            migrationBuilder.DropColumn(
                name: "ParameterValue",
                table: "ProcessClaim");

            migrationBuilder.CreateTable(
                name: "ClaimServiceDetail",
                columns: table => new
                {
                    ClaimServiceDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimCode = table.Column<int>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastClaimDetails = table.Column<string>(nullable: true),
                    LastServiceDetails = table.Column<string>(nullable: true),
                    ParameterCode = table.Column<int>(nullable: false),
                    ParameterValue = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimServiceDetail", x => x.ClaimServiceDetailID);
                    table.ForeignKey(
                        name: "FK_ClaimServiceDetail_ProcessClaim_ClaimCode",
                        column: x => x.ClaimCode,
                        principalTable: "ProcessClaim",
                        principalColumn: "ClaimCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimServiceDetail_ClaimCode",
                table: "ClaimServiceDetail",
                column: "ClaimCode");
        }
    }
}
