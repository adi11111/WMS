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
                name: "Locations",
                columns: table => new
                {
                    LocationCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    LocationName = table.Column<string>(nullable: true),
                    SINum = table.Column<int>(nullable: false),
                    WEMSLocationCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationCode);
                });

            migrationBuilder.CreateTable(
                name: "ProcessClaimDetaisl",
                columns: table => new
                {
                    ClaimCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    ActualCost = table.Column<string>(nullable: true),
                    ClaimDtlId = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    FaultCode = table.Column<int>(nullable: false),
                    FinalCost = table.Column<string>(nullable: true),
                    IUD = table.Column<string>(nullable: true),
                    Inspection = table.Column<string>(nullable: true),
                    InspectionNo = table.Column<string>(nullable: true),
                    IsInspectionDone = table.Column<string>(nullable: true),
                    IsService = table.Column<string>(nullable: true),
                    LaborCost = table.Column<string>(nullable: true),
                    LaborDisPer = table.Column<float>(nullable: false),
                    MfgDisPer = table.Column<float>(nullable: false),
                    OtherCost = table.Column<string>(nullable: true),
                    PartCategory = table.Column<int>(nullable: false),
                    PartCode = table.Column<int>(nullable: false),
                    PartSRNumber = table.Column<int>(nullable: false),
                    RepairerDisPer = table.Column<float>(nullable: false),
                    ServiceDisPerc = table.Column<string>(nullable: true),
                    Total = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessClaimDetaisl", x => x.ClaimCode);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    ProgramName = table.Column<string>(nullable: true),
                    SINum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
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
                name: "UserDealerBranchFilters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    BranchCode = table.Column<int>(nullable: false),
                    DealerCode = table.Column<int>(nullable: false),
                    UserCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDealerBranchFilters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserDealerFilters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    DealerCode = table.Column<int>(nullable: false),
                    UserCode = table.Column<int>(nullable: false),
                    UserRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDealerFilters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkshopFilters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    DealerCode = table.Column<int>(nullable: false),
                    UserCode = table.Column<int>(nullable: false),
                    WorkshopCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkshopFilters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyTypes",
                columns: table => new
                {
                    WarrantyTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    SINum = table.Column<int>(nullable: false),
                    WarrantyTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyTypes", x => x.WarrantyTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    ConfigID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    IUD = table.Column<string>(nullable: true),
                    LocationCode = table.Column<int>(nullable: false),
                    ProgramCode = table.Column<int>(nullable: false),
                    TownCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.ConfigID);
                    table.ForeignKey(
                        name: "FK_Config_Locations_LocationCode",
                        column: x => x.LocationCode,
                        principalTable: "Locations",
                        principalColumn: "LocationCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Config_Programs_ProgramCode",
                        column: x => x.ProgramCode,
                        principalTable: "Programs",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccGroup",
                columns: table => new
                {
                    GroupCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    Abbreviation = table.Column<string>(nullable: true),
                    ConfigID = table.Column<int>(nullable: false),
                    FYCode = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(nullable: true),
                    IUD = table.Column<int>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    LedgerStartNo = table.Column<int>(nullable: false),
                    NatureOfGroup = table.Column<string>(nullable: true),
                    OldGroupCode = table.Column<int>(nullable: false),
                    OldParentGroupCode = table.Column<int>(nullable: false),
                    ParentGroupCode = table.Column<int>(nullable: false),
                    PrintOrder = table.Column<int>(nullable: false),
                    SystemProvider = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccGroup", x => x.GroupCode);
                    table.ForeignKey(
                        name: "FK_AccGroup_Config_ConfigID",
                        column: x => x.ConfigID,
                        principalTable: "Config",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    ParameterCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    ConfigID = table.Column<int>(nullable: false),
                    ControlType = table.Column<string>(nullable: true),
                    DataType = table.Column<string>(nullable: true),
                    IUD = table.Column<string>(nullable: true),
                    IsServiceable = table.Column<string>(nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    ParameterName = table.Column<string>(nullable: true),
                    ParentParameterCode = table.Column<int>(nullable: false),
                    PremiumDecider = table.Column<string>(nullable: true),
                    SystemProvided = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.ParameterCode);
                    table.ForeignKey(
                        name: "FK_Parameter_Config_ConfigID",
                        column: x => x.ConfigID,
                        principalTable: "Config",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Preimiums",
                columns: table => new
                {
                    PremiumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    CateogoryID = table.Column<int>(nullable: false),
                    ConfigID = table.Column<int>(nullable: false),
                    DealerID = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    PremiumPercentage = table.Column<float>(nullable: false),
                    ProductSubGroupID = table.Column<int>(nullable: false),
                    ProgramID = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SINum = table.Column<int>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<float>(nullable: false),
                    WarrantyTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preimiums", x => x.PremiumID);
                    table.ForeignKey(
                        name: "FK_Preimiums_Config_ConfigID",
                        column: x => x.ConfigID,
                        principalTable: "Config",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Preimiums_WarrantyTypes_WarrantyTypeID",
                        column: x => x.WarrantyTypeID,
                        principalTable: "WarrantyTypes",
                        principalColumn: "WarrantyTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSubGroup",
                columns: table => new
                {
                    SubGroupCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
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
                    table.ForeignKey(
                        name: "FK_ProductSubGroup_Config_ConfigID",
                        column: x => x.ConfigID,
                        principalTable: "Config",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkShops",
                columns: table => new
                {
                    WorkshopCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    AccGroupCode = table.Column<int>(nullable: false),
                    ConfigID = table.Column<int>(nullable: false),
                    ContactPerson = table.Column<string>(nullable: true),
                    DeactivationComment = table.Column<string>(nullable: true),
                    DeactivationDate = table.Column<DateTime>(nullable: false),
                    DealerCode = table.Column<int>(nullable: false),
                    IUD = table.Column<int>(nullable: false),
                    IntroductionDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<string>(nullable: true),
                    LabourDiscountPercentage = table.Column<float>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    LedgerCode = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    MfgDiscountPercentage = table.Column<float>(nullable: false),
                    MobileNo = table.Column<string>(nullable: true),
                    OlderLedgerCode = table.Column<int>(nullable: false),
                    OtherDiscountPercentage = table.Column<float>(nullable: false),
                    POBoxNo = table.Column<string>(nullable: true),
                    PagerNo = table.Column<string>(nullable: true),
                    RepairerDiscountPercentage = table.Column<float>(nullable: false),
                    ServiceFaxNo = table.Column<string>(nullable: true),
                    ServicePhoneNo = table.Column<string>(nullable: true),
                    WorkshopAddress = table.Column<string>(nullable: true),
                    WorkshopName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShops", x => x.WorkshopCode);
                    table.ForeignKey(
                        name: "FK_WorkShops_Config_ConfigID",
                        column: x => x.ConfigID,
                        principalTable: "Config",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccLedger",
                columns: table => new
                {
                    LedgerCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    AccGroupCode = table.Column<int>(nullable: false),
                    ConfigID = table.Column<int>(nullable: false),
                    DRCR = table.Column<int>(nullable: false),
                    DeactivationDate = table.Column<DateTime>(nullable: false),
                    FYCode = table.Column<int>(nullable: false),
                    IUD = table.Column<string>(nullable: true),
                    IsActive = table.Column<string>(nullable: true),
                    IsAutoEntry = table.Column<string>(nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    LedgerName = table.Column<string>(nullable: true),
                    OldAccGrpCode = table.Column<int>(nullable: false),
                    OldLedgerCode = table.Column<int>(nullable: false),
                    OpeningBalance = table.Column<string>(nullable: true),
                    SystemProvided = table.Column<int>(nullable: false),
                    TYCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccLedger", x => x.LedgerCode);
                    table.ForeignKey(
                        name: "FK_AccLedger_AccGroup_AccGroupCode",
                        column: x => x.AccGroupCode,
                        principalTable: "AccGroup",
                        principalColumn: "GroupCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccLedger_Config_ConfigID",
                        column: x => x.ConfigID,
                        principalTable: "Config",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dealers",
                columns: table => new
                {
                    DealerCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    AccGroupCode = table.Column<int>(nullable: false),
                    AccountContactNo = table.Column<string>(nullable: true),
                    AccountContactPerson = table.Column<string>(nullable: true),
                    AccountFaxNo = table.Column<string>(nullable: true),
                    AccountPhoneNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BWPremiumPerc = table.Column<float>(nullable: false),
                    ConfigID = table.Column<int>(nullable: false),
                    DeactivationDate = table.Column<DateTime>(nullable: false),
                    DealerName = table.Column<string>(nullable: true),
                    DeductableValue = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IUD = table.Column<string>(nullable: true),
                    IsActive = table.Column<string>(nullable: true),
                    IsSelfAuthorityLimit = table.Column<string>(nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    LedgerCode = table.Column<int>(nullable: false),
                    NoOfInstalments = table.Column<int>(nullable: false),
                    OldDealerCode = table.Column<int>(nullable: false),
                    OldLedgerCode = table.Column<int>(nullable: false),
                    PrivateSale = table.Column<int>(nullable: false),
                    SaleFaxNo = table.Column<string>(nullable: true),
                    SalesPhoneNo = table.Column<string>(nullable: true),
                    SelfAuthorityLimit = table.Column<string>(nullable: true),
                    ServiceContactPerson = table.Column<string>(nullable: true),
                    SubGroupCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dealers", x => x.DealerCode);
                    table.ForeignKey(
                        name: "FK_Dealers_AccGroup_AccGroupCode",
                        column: x => x.AccGroupCode,
                        principalTable: "AccGroup",
                        principalColumn: "GroupCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dealers_Config_ConfigID",
                        column: x => x.ConfigID,
                        principalTable: "Config",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Dealers_AccLedger_LedgerCode",
                        column: x => x.LedgerCode,
                        principalTable: "AccLedger",
                        principalColumn: "LedgerCode",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Dealers_ProductSubGroup_SubGroupCode",
                        column: x => x.SubGroupCode,
                        principalTable: "ProductSubGroup",
                        principalColumn: "SubGroupCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
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
                    table.PrimaryKey("PK_Policies", x => x.PolNumber);
                    table.ForeignKey(
                        name: "FK_Policies_Dealers_DealerID",
                        column: x => x.DealerID,
                        principalTable: "Dealers",
                        principalColumn: "DealerCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policies_Locations_LocationCode",
                        column: x => x.LocationCode,
                        principalTable: "Locations",
                        principalColumn: "LocationCode",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Policies_ProductSubGroup_ProductSubGroupId",
                        column: x => x.ProductSubGroupId,
                        principalTable: "ProductSubGroup",
                        principalColumn: "SubGroupCode",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Policies_Programs_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Programs",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProcessClaims",
                columns: table => new
                {
                    ClaimCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo),
                    ActualClaimAmount = table.Column<string>(nullable: true),
                    ActualInvoiceAmt = table.Column<string>(nullable: true),
                    ArigPaidAmountUSD = table.Column<string>(nullable: true),
                    ArigRejection = table.Column<string>(nullable: true),
                    ArigRejectionCode = table.Column<string>(nullable: true),
                    BranchCode = table.Column<int>(nullable: false),
                    ClaimFrom = table.Column<int>(nullable: false),
                    ClaimNo = table.Column<string>(nullable: true),
                    ConfigID = table.Column<int>(nullable: false),
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
                    TotalServiceCost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessClaims", x => x.ClaimCode);
                    table.ForeignKey(
                        name: "FK_ProcessClaims_Config_ConfigID",
                        column: x => x.ConfigID,
                        principalTable: "Config",
                        principalColumn: "ConfigID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProcessClaims_Policies_PolicyCode",
                        column: x => x.PolicyCode,
                        principalTable: "Policies",
                        principalColumn: "PolNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimServiceDetails",
                columns: table => new
                {
                    ClaimCode = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    IUD = table.Column<string>(nullable: true),
                    LastClaimDetails = table.Column<string>(nullable: true),
                    LastServiceDetails = table.Column<string>(nullable: true),
                    ParameterCode = table.Column<int>(nullable: false),
                    ParameterValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimServiceDetails", x => x.ClaimCode);
                    table.ForeignKey(
                        name: "FK_ClaimServiceDetails_ProcessClaims_ClaimCode",
                        column: x => x.ClaimCode,
                        principalTable: "ProcessClaims",
                        principalColumn: "ClaimCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimServiceDetails_Parameter_ParameterCode",
                        column: x => x.ParameterCode,
                        principalTable: "Parameter",
                        principalColumn: "ParameterCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimsStatus",
                columns: table => new
                {
                    ClaimCode = table.Column<int>(nullable: false),
                    AutoID = table.Column<float>(nullable: false),
                    ClaimStatus = table.Column<int>(nullable: false),
                    IUD = table.Column<int>(nullable: false),
                    LastModifiedBy = table.Column<int>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    StatusCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimsStatus", x => x.ClaimCode);
                    table.ForeignKey(
                        name: "FK_ClaimsStatus_ProcessClaims_ClaimCode",
                        column: x => x.ClaimCode,
                        principalTable: "ProcessClaims",
                        principalColumn: "ClaimCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccGroup_ConfigID",
                table: "AccGroup",
                column: "ConfigID");

            migrationBuilder.CreateIndex(
                name: "IX_AccLedger_AccGroupCode",
                table: "AccLedger",
                column: "AccGroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_AccLedger_ConfigID",
                table: "AccLedger",
                column: "ConfigID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimServiceDetails_ParameterCode",
                table: "ClaimServiceDetails",
                column: "ParameterCode");

            migrationBuilder.CreateIndex(
                name: "IX_Config_LocationCode",
                table: "Config",
                column: "LocationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Config_ProgramCode",
                table: "Config",
                column: "ProgramCode");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_AccGroupCode",
                table: "Dealers",
                column: "AccGroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_ConfigID",
                table: "Dealers",
                column: "ConfigID");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_LedgerCode",
                table: "Dealers",
                column: "LedgerCode");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_SubGroupCode",
                table: "Dealers",
                column: "SubGroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_ConfigID",
                table: "Parameter",
                column: "ConfigID");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_DealerID",
                table: "Policies",
                column: "DealerID");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_LocationCode",
                table: "Policies",
                column: "LocationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_ProductSubGroupId",
                table: "Policies",
                column: "ProductSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_ProgramID",
                table: "Policies",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Preimiums_ConfigID",
                table: "Preimiums",
                column: "ConfigID");

            migrationBuilder.CreateIndex(
                name: "IX_Preimiums_WarrantyTypeID",
                table: "Preimiums",
                column: "WarrantyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessClaims_ConfigID",
                table: "ProcessClaims",
                column: "ConfigID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessClaims_PolicyCode",
                table: "ProcessClaims",
                column: "PolicyCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubGroup_ConfigID",
                table: "ProductSubGroup",
                column: "ConfigID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShops_ConfigID",
                table: "WorkShops",
                column: "ConfigID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimServiceDetails");

            migrationBuilder.DropTable(
                name: "ClaimsStatus");

            migrationBuilder.DropTable(
                name: "Preimiums");

            migrationBuilder.DropTable(
                name: "ProcessClaimDetaisl");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserDealerBranchFilters");

            migrationBuilder.DropTable(
                name: "UserDealerFilters");

            migrationBuilder.DropTable(
                name: "UserWorkshopFilters");

            migrationBuilder.DropTable(
                name: "WorkShops");

            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "ProcessClaims");

            migrationBuilder.DropTable(
                name: "WarrantyTypes");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Dealers");

            migrationBuilder.DropTable(
                name: "AccLedger");

            migrationBuilder.DropTable(
                name: "ProductSubGroup");

            migrationBuilder.DropTable(
                name: "AccGroup");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
