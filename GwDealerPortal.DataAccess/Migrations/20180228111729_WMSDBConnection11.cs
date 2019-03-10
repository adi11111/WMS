using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Premium");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Premium",
                columns: table => new
                {
                    PremiumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    ConfigID = table.Column<int>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DealerID = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PremiumPercentage = table.Column<float>(nullable: false),
                    ProductSubGroupID = table.Column<int>(nullable: false),
                    ProgramID = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SINum = table.Column<int>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<float>(nullable: false),
                    WarrantyTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.PremiumID);
                });
        }
    }
}
