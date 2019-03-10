using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preimium_WarrantyType_WarrantyTypeID",
                table: "Preimium");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Preimium",
                table: "Preimium");

            migrationBuilder.RenameTable(
                name: "Preimium",
                newName: "Premium");

            migrationBuilder.RenameIndex(
                name: "IX_Preimium_WarrantyTypeID",
                table: "Premium",
                newName: "IX_Premium_WarrantyTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Premium",
                table: "Premium",
                column: "PremiumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Premium_WarrantyType_WarrantyTypeID",
                table: "Premium",
                column: "WarrantyTypeID",
                principalTable: "WarrantyType",
                principalColumn: "WarrantyTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premium_WarrantyType_WarrantyTypeID",
                table: "Premium");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Premium",
                table: "Premium");

            migrationBuilder.RenameTable(
                name: "Premium",
                newName: "Preimium");

            migrationBuilder.RenameIndex(
                name: "IX_Premium_WarrantyTypeID",
                table: "Preimium",
                newName: "IX_Preimium_WarrantyTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Preimium",
                table: "Preimium",
                column: "PremiumID");

            migrationBuilder.AddForeignKey(
                name: "FK_Preimium_WarrantyType_WarrantyTypeID",
                table: "Preimium",
                column: "WarrantyTypeID",
                principalTable: "WarrantyType",
                principalColumn: "WarrantyTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
