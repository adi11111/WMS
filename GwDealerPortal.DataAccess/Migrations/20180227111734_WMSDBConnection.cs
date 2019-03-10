using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GwDealerPortal.DataAccess.Migrations
{
    public partial class WMSDBConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimServiceDetail", x => x.ClaimServiceDetailID);
                });

            migrationBuilder.CreateTable(
                name: "Dealer",
                columns: table => new
                {
                    DealerCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccGroupCode = table.Column<int>(nullable: false),
                    AccountContactNo = table.Column<string>(nullable: true),
                    AccountContactPerson = table.Column<string>(nullable: true),
                    AccountFaxNo = table.Column<string>(nullable: true),
                    AccountPhoneNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BWPremiumPerc = table.Column<float>(nullable: false),
                    ConfigID = table.Column<int>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeactivationDate = table.Column<DateTime>(nullable: false),
                    DealerName = table.Column<string>(nullable: true),
                    DeductableValue = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IUD = table.Column<string>(nullable: true),
                    IsActive = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsSelfAuthorityLimit = table.Column<string>(nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    LedgerCode = table.Column<int>(nullable: false),
                    NoOfInstalments = table.Column<int>(nullable: false),
                    OldDealerCode = table.Column<int>(nullable: false),
                    OldLedgerCode = table.Column<int>(nullable: false),
                    PrivateSale = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SaleFaxNo = table.Column<string>(nullable: true),
                    SalesPhoneNo = table.Column<string>(nullable: true),
                    SelfAuthorityLimit = table.Column<string>(nullable: true),
                    ServiceContactPerson = table.Column<string>(nullable: true),
                    SubGroupCode = table.Column<int>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealer", x => x.DealerCode);
                });

            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    FilterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FilterName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.FilterID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LocationName = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    SINum = table.Column<int>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    WEMSLocationCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationCode);
                });

            migrationBuilder.CreateTable(
                name: "ProcessClaimDetail",
                columns: table => new
                {
                    ProcessClaimDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualCost = table.Column<string>(nullable: true),
                    ClaimCode = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FaultCode = table.Column<int>(nullable: false),
                    FinalCost = table.Column<string>(nullable: true),
                    Inspection = table.Column<string>(nullable: true),
                    InspectionNo = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsInspectionDone = table.Column<string>(nullable: true),
                    IsService = table.Column<string>(nullable: true),
                    LaborCost = table.Column<string>(nullable: true),
                    LaborDisPer = table.Column<float>(nullable: false),
                    MfgDisPer = table.Column<float>(nullable: false),
                    OtherCost = table.Column<string>(nullable: true),
                    PartCategory = table.Column<int>(nullable: false),
                    PartCode = table.Column<int>(nullable: false),
                    PartSRNumber = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    RepairerDisPer = table.Column<float>(nullable: false),
                    ServiceDisPerc = table.Column<string>(nullable: true),
                    Total = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessClaimDetail", x => x.ProcessClaimDetailID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubGroup",
                columns: table => new
                {
                    SubGroupCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConfigID = table.Column<int>(nullable: false),
                    DefaultTransferFees = table.Column<float>(nullable: false),
                    IUD = table.Column<string>(nullable: true),
                    IsPercentage = table.Column<string>(nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    MISProgramType = table.Column<int>(nullable: false),
                    OldPolicyTypeID = table.Column<int>(nullable: false),
                    PolInputDaysLimitMax = table.Column<int>(nullable: false),
                    PolInputDaysLimitMin = table.Column<int>(nullable: false),
                    ProductGroupCode = table.Column<int>(nullable: false),
                    ReOrderLevel = table.Column<int>(nullable: false),
                    SubGroupName = table.Column<string>(nullable: true),
                    TermsAndConditions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubGroup", x => x.SubGroupCode);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProgramName = table.Column<string>(nullable: true),
                    SINum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramID);
                });

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

            migrationBuilder.CreateTable(
                name: "UserFilter",
                columns: table => new
                {
                    UserFilterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EventAccess = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserRoleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilter", x => x.UserFilterID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserRoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleID);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyType",
                columns: table => new
                {
                    WarrantyTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SINum = table.Column<int>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    WarrantyTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyType", x => x.WarrantyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    PolNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    ClaimLimit = table.Column<string>(nullable: true),
                    ClientRefNum = table.Column<string>(nullable: true),
                    CustName = table.Column<string>(nullable: true),
                    DealerID = table.Column<int>(nullable: false),
                    DealerName = table.Column<string>(nullable: true),
                    Discount = table.Column<float>(nullable: false),
                    DocNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<string>(nullable: true),
                    ExtCutoff = table.Column<string>(nullable: true),
                    ExtDuration = table.Column<int>(nullable: false),
                    IssueDate = table.Column<string>(nullable: true),
                    LocationCode = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    ManuCutoff = table.Column<string>(nullable: true),
                    ManuDuration = table.Column<int>(nullable: false),
                    ManuExpiryDate = table.Column<string>(nullable: true),
                    MobileNum = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    ModelYear = table.Column<int>(nullable: false),
                    Premium = table.Column<float>(nullable: false),
                    PremiumPercentage = table.Column<float>(nullable: false),
                    ProductGroup = table.Column<string>(nullable: true),
                    ProductGroupId = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<float>(nullable: false),
                    ProductSubGroupId = table.Column<int>(nullable: false),
                    ProductSubGroupName = table.Column<string>(nullable: true),
                    ProgramID = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SINum = table.Column<int>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    SizeRange = table.Column<string>(nullable: true),
                    SoldBy = table.Column<string>(nullable: true),
                    SoldDate = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    SubCategory = table.Column<string>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: false),
                    UINumber = table.Column<string>(nullable: true),
                    WarrantyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.PolNumber);
                    table.ForeignKey(
                        name: "FK_Policy_Dealer_DealerID",
                        column: x => x.DealerID,
                        principalTable: "Dealer",
                        principalColumn: "DealerCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policy_Location_LocationCode",
                        column: x => x.LocationCode,
                        principalTable: "Location",
                        principalColumn: "LocationCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policy_ProductSubGroup_ProductSubGroupId",
                        column: x => x.ProductSubGroupId,
                        principalTable: "ProductSubGroup",
                        principalColumn: "SubGroupCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policy_Program_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Program",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preimium",
                columns: table => new
                {
                    PremiumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CateogoryID = table.Column<int>(nullable: false),
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
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<float>(nullable: false),
                    WarrantyTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preimium", x => x.PremiumID);
                    table.ForeignKey(
                        name: "FK_Preimium_WarrantyType_WarrantyTypeID",
                        column: x => x.WarrantyTypeID,
                        principalTable: "WarrantyType",
                        principalColumn: "WarrantyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessClaim",
                columns: table => new
                {
                    ClaimCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualClaimAmount = table.Column<string>(nullable: true),
                    ActualInvoiceAmt = table.Column<string>(nullable: true),
                    ArigPaidAmountUSD = table.Column<string>(nullable: true),
                    ArigRejection = table.Column<string>(nullable: true),
                    ArigRejectionCode = table.Column<string>(nullable: true),
                    BranchCode = table.Column<int>(nullable: false),
                    ClaimFrom = table.Column<int>(nullable: false),
                    ClaimNo = table.Column<string>(nullable: true),
                    ConfigID = table.Column<int>(nullable: false),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<int>(nullable: false),
                    CustomerInvoiceDate = table.Column<DateTime>(nullable: false),
                    CustomerInvoiceNo = table.Column<string>(nullable: true),
                    CustomerInvoiceReceivedOn = table.Column<DateTime>(nullable: false),
                    DateOfFailure = table.Column<DateTime>(nullable: false),
                    DeductableAmount = table.Column<string>(nullable: true),
                    ExchangeRate = table.Column<float>(nullable: false),
                    FYCode = table.Column<int>(nullable: false),
                    FaxReceivedDate = table.Column<DateTime>(nullable: false),
                    FaxReceivedTime = table.Column<string>(nullable: true),
                    IUD = table.Column<string>(nullable: true),
                    InspectionNo = table.Column<string>(nullable: true),
                    Inspector = table.Column<string>(nullable: true),
                    InspectorComments = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsFirstAboveCover = table.Column<string>(nullable: true),
                    IsInspectionDone = table.Column<string>(nullable: true),
                    IsSPR = table.Column<string>(nullable: true),
                    LaborCostAftDisc = table.Column<string>(nullable: true),
                    LabourCharges = table.Column<string>(nullable: true),
                    LabourDiscountPer = table.Column<float>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    LastServiceDate = table.Column<DateTime>(nullable: false),
                    Legal = table.Column<string>(nullable: true),
                    MajorFaultCode = table.Column<string>(nullable: true),
                    OldClaimCode = table.Column<int>(nullable: false),
                    OtherDiscountPer = table.Column<float>(nullable: false),
                    OverLimitReasonDesc = table.Column<string>(nullable: true),
                    PartsCostAftDisc = table.Column<string>(nullable: true),
                    PayeeID = table.Column<int>(nullable: false),
                    PolicyCode = table.Column<string>(nullable: true),
                    ReasonForRejectionHold = table.Column<string>(nullable: true),
                    ReasonInspNotDone = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    RepairerComments = table.Column<string>(nullable: true),
                    RepairerID = table.Column<int>(nullable: false),
                    RequestedAmount = table.Column<string>(nullable: true),
                    SPDetails = table.Column<string>(nullable: true),
                    ServiceCharges = table.Column<string>(nullable: true),
                    ServiceDiscountPer = table.Column<float>(nullable: false),
                    TaxPer = table.Column<float>(nullable: false),
                    TaxValue = table.Column<string>(nullable: true),
                    TotalClaimAmount = table.Column<string>(nullable: true),
                    TotalLabourCost = table.Column<string>(nullable: true),
                    TotalOtherDiscount = table.Column<float>(nullable: false),
                    TotalPartsCost = table.Column<string>(nullable: true),
                    TotalServiceCost = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessClaim", x => x.ClaimCode);
                    table.ForeignKey(
                        name: "FK_ProcessClaim_Policy_PolicyCode",
                        column: x => x.PolicyCode,
                        principalTable: "Policy",
                        principalColumn: "PolNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimsStatus",
                columns: table => new
                {
                    SlNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimCode = table.Column<int>(nullable: false),
                    ClaimStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimsStatus", x => x.SlNumber);
                    table.ForeignKey(
                        name: "FK_ClaimsStatus_ProcessClaim_ClaimCode",
                        column: x => x.ClaimCode,
                        principalTable: "ProcessClaim",
                        principalColumn: "ClaimCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimsStatus_ClaimCode",
                table: "ClaimsStatus",
                column: "ClaimCode");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_DealerID",
                table: "Policy",
                column: "DealerID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_LocationCode",
                table: "Policy",
                column: "LocationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_ProductSubGroupId",
                table: "Policy",
                column: "ProductSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_ProgramID",
                table: "Policy",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Preimium_WarrantyTypeID",
                table: "Preimium",
                column: "WarrantyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessClaim_PolicyCode",
                table: "ProcessClaim",
                column: "PolicyCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimServiceDetail");

            migrationBuilder.DropTable(
                name: "ClaimsStatus");

            migrationBuilder.DropTable(
                name: "Filter");

            migrationBuilder.DropTable(
                name: "Preimium");

            migrationBuilder.DropTable(
                name: "ProcessClaimDetail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserFilter");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "ProcessClaim");

            migrationBuilder.DropTable(
                name: "WarrantyType");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Dealer");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "ProductSubGroup");

            migrationBuilder.DropTable(
                name: "Program");
        }
    }
}
