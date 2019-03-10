using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            
        

            migrationBuilder.CreateTable(
                name: "OtherService",
                columns: table => new
                {
                    OtherServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OtherServiceName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherService", x => x.OtherServiceID);
                });

            migrationBuilder.CreateTable(
                name: "PolicyService",
                columns: table => new
                {
                    PolicyServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolicyID = table.Column<int>(nullable: false),
                    ServiceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyService", x => x.PolicyServiceID);
                });
                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CCRange");

            migrationBuilder.DropTable(
                name: "DealerBranch");

            migrationBuilder.DropTable(
                name: "ModelYear");

            migrationBuilder.DropTable(
                name: "OtherService");

            migrationBuilder.DropTable(
                name: "PolicyService");

            migrationBuilder.DropColumn(
                name: "CCRangeId",
                table: "Policy");

            migrationBuilder.RenameColumn(
                name: "ModelYearId",
                table: "Policy",
                newName: "ModelYear");

            migrationBuilder.AddColumn<string>(
                name: "CCRange",
                table: "Policy",
                nullable: true);
        }
    }
}
