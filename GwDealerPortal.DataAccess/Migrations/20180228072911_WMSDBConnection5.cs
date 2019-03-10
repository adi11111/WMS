using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    PolNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    CC = table.Column<int>(nullable: true),
                    CCRange = table.Column<string>(nullable: true),
                    Capacity = table.Column<string>(nullable: true),
                    CapacityRange = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    ClaimLimit = table.Column<string>(nullable: true),
                    ClientRefNum = table.Column<string>(nullable: true),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CurrentMileage = table.Column<float>(nullable: true),
                    CustName = table.Column<string>(nullable: true),
                    DealerID = table.Column<int>(nullable: false),
                    DealerName = table.Column<string>(nullable: true),
                    Discount = table.Column<float>(nullable: false),
                    DocNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    ExtCutoff = table.Column<string>(nullable: true),
                    ExtDuration = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: true),
                    LocationCode = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    ManuCutoff = table.Column<string>(nullable: true),
                    ManuDuration = table.Column<int>(nullable: false),
                    ManuExpiryDate = table.Column<DateTime>(nullable: true),
                    MobileNum = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    ModelYear = table.Column<int>(nullable: false),
                    PlateType = table.Column<string>(nullable: true),
                    Premium = table.Column<float>(nullable: false),
                    PremiumPercentage = table.Column<float>(nullable: false),
                    ProductGroup = table.Column<string>(nullable: true),
                    ProductGroupId = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<float>(nullable: false),
                    ProductSubGroupId = table.Column<int>(nullable: false),
                    ProductSubGroupName = table.Column<string>(nullable: true),
                    ProgramID = table.Column<int>(nullable: false),
                    RegDate = table.Column<DateTime>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SINum = table.Column<int>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    SizeRange = table.Column<string>(nullable: true),
                    SoldBy = table.Column<string>(nullable: true),
                    SoldDate = table.Column<DateTime>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    SubCategory = table.Column<string>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: false),
                    UINumber = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.PolNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy");
        }
    }
}
