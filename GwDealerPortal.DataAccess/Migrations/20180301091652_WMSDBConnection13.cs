using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimApprovalLimit = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IUD = table.Column<int>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    OldUserID = table.Column<int>(nullable: false),
                    PasswordExpiryInDays = table.Column<int>(nullable: false),
                    PersonName = table.Column<string>(nullable: true),
                    RoleCode = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserCode);
                });
        }
    }
}
