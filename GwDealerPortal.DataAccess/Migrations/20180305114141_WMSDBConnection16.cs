using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProcessClaimDetail_ClaimCode",
                table: "ProcessClaimDetail",
                column: "ClaimCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimsStatus_ClaimCode",
                table: "ClaimsStatus",
                column: "ClaimCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimServiceDetail_ClaimCode",
                table: "ClaimServiceDetail",
                column: "ClaimCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimServiceDetail_ProcessClaim_ClaimCode",
                table: "ClaimServiceDetail",
                column: "ClaimCode",
                principalTable: "ProcessClaim",
                principalColumn: "ClaimCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimsStatus_ProcessClaim_ClaimCode",
                table: "ClaimsStatus",
                column: "ClaimCode",
                principalTable: "ProcessClaim",
                principalColumn: "ClaimCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessClaimDetail_ProcessClaim_ClaimCode",
                table: "ProcessClaimDetail",
                column: "ClaimCode",
                principalTable: "ProcessClaim",
                principalColumn: "ClaimCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimServiceDetail_ProcessClaim_ClaimCode",
                table: "ClaimServiceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ClaimsStatus_ProcessClaim_ClaimCode",
                table: "ClaimsStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessClaimDetail_ProcessClaim_ClaimCode",
                table: "ProcessClaimDetail");

            migrationBuilder.DropIndex(
                name: "IX_ProcessClaimDetail_ClaimCode",
                table: "ProcessClaimDetail");

            migrationBuilder.DropIndex(
                name: "IX_ClaimsStatus_ClaimCode",
                table: "ClaimsStatus");

            migrationBuilder.DropIndex(
                name: "IX_ClaimServiceDetail_ClaimCode",
                table: "ClaimServiceDetail");
        }
    }
}
