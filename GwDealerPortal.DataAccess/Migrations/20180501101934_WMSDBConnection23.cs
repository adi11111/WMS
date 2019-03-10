using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BWDealerPolicy",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    ClientRefNumber = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    DealerName = table.Column<string>(nullable: true),
                    ExtendedWarrantyDuration = table.Column<int>(nullable: false),
                    ExtendedWarrantyEndDate = table.Column<DateTime>(nullable: false),
                    ExtendedWarrantyStartDate = table.Column<DateTime>(nullable: false),
                    ExtendedWarrantyType = table.Column<string>(nullable: true),
                    GrossPremium = table.Column<decimal>(nullable: false),
                    GrossPremiumPercentage = table.Column<decimal>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ManufacturerWarrantyDuration = table.Column<int>(nullable: false),
                    ManufacturerWarrantyEndDate = table.Column<DateTime>(nullable: false),
                    ManufacturerWarrantyStartDate = table.Column<DateTime>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    ModelYear = table.Column<int>(nullable: false),
                    PolicyNumber = table.Column<string>(nullable: true),
                    ProductCategory = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ProductType = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SalesMan = table.Column<string>(nullable: true),
                    UIN = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BWDealerPolicy", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BWDealerPolicy");
        }
    }
}
