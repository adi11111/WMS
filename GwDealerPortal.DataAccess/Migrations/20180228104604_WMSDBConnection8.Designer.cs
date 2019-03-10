﻿// <auto-generated />
using GwDealerPortal.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GwDealerPortal.DataAccess.Migrations
{
    [DbContext(typeof(WMSDBContext))]
    [Migration("20180228104604_WMSDBConnection8")]
    partial class WMSDBConnection8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.ClaimServiceDetail", b =>
                {
                    b.Property<int>("ClaimServiceDetailID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClaimCode");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastClaimDetails");

                    b.Property<string>("LastServiceDetails");

                    b.Property<int>("ParameterCode");

                    b.Property<string>("ParameterValue");

                    b.Property<string>("Remarks");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ClaimServiceDetailID");

                    b.ToTable("ClaimServiceDetail");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.ClaimsStatus", b =>
                {
                    b.Property<int>("SlNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClaimCode");

                    b.Property<int>("ClaimStatus");

                    b.HasKey("SlNumber");

                    b.ToTable("ClaimsStatus");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.Dealer", b =>
                {
                    b.Property<int>("DealerCode")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccGroupCode");

                    b.Property<string>("AccountContactNo");

                    b.Property<string>("AccountContactPerson");

                    b.Property<string>("AccountFaxNo");

                    b.Property<string>("AccountPhoneNo");

                    b.Property<string>("Address");

                    b.Property<float>("BWPremiumPerc");

                    b.Property<int>("ConfigID");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DeactivationDate");

                    b.Property<string>("DealerName");

                    b.Property<string>("DeductableValue");

                    b.Property<string>("Email");

                    b.Property<string>("IUD");

                    b.Property<string>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("IsSelfAuthorityLimit");

                    b.Property<int>("LedgerCode");

                    b.Property<int>("NoOfInstalments");

                    b.Property<int>("OldDealerCode");

                    b.Property<int>("OldLedgerCode");

                    b.Property<int>("PrivateSale");

                    b.Property<string>("Remarks");

                    b.Property<string>("SaleFaxNo");

                    b.Property<string>("SalesPhoneNo");

                    b.Property<string>("SelfAuthorityLimit");

                    b.Property<string>("ServiceContactPerson");

                    b.Property<int>("SubGroupCode");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("DealerCode");

                    b.ToTable("Dealer");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.Filter", b =>
                {
                    b.Property<int>("FilterID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FilterName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Remarks");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("FilterID");

                    b.ToTable("Filter");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.Location", b =>
                {
                    b.Property<int>("LocationCode")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LocationName");

                    b.Property<string>("Remarks");

                    b.Property<int>("SINum");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int>("WEMSLocationCode");

                    b.HasKey("LocationCode");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.Policy", b =>
                {
                    b.Property<int>("SINum")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Branch");

                    b.Property<int?>("CC");

                    b.Property<string>("CCRange");

                    b.Property<string>("Capacity");

                    b.Property<string>("CapacityRange");

                    b.Property<string>("Category");

                    b.Property<int>("CategoryId");

                    b.Property<string>("City");

                    b.Property<string>("ClaimLimit");

                    b.Property<string>("ClientRefNum");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<float?>("CurrentMileage");

                    b.Property<string>("CustName");

                    b.Property<int>("DealerID");

                    b.Property<string>("DealerName");

                    b.Property<float>("Discount");

                    b.Property<string>("DocNumber");

                    b.Property<string>("Email");

                    b.Property<DateTime?>("ExpiryDate");

                    b.Property<string>("ExtCutoff");

                    b.Property<int>("ExtDuration");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("IssueDate");

                    b.Property<int>("LocationCode");

                    b.Property<string>("Make");

                    b.Property<string>("ManuCutoff");

                    b.Property<int>("ManuDuration");

                    b.Property<DateTime?>("ManuExpiryDate");

                    b.Property<string>("MobileNum");

                    b.Property<string>("Model");

                    b.Property<int>("ModelYear");

                    b.Property<string>("PlateType");

                    b.Property<string>("PolNumber");

                    b.Property<float>("Premium");

                    b.Property<float>("PremiumPercentage");

                    b.Property<string>("ProductGroup");

                    b.Property<int>("ProductGroupId");

                    b.Property<float>("ProductPrice");

                    b.Property<int>("ProductSubGroupId");

                    b.Property<string>("ProductSubGroupName");

                    b.Property<int>("ProgramID");

                    b.Property<DateTime?>("RegDate");

                    b.Property<string>("RegNumber");

                    b.Property<string>("Remarks");

                    b.Property<string>("Size");

                    b.Property<string>("SizeRange");

                    b.Property<string>("SoldBy");

                    b.Property<DateTime?>("SoldDate");

                    b.Property<DateTime?>("StartDate");

                    b.Property<bool>("Status");

                    b.Property<string>("SubCategory");

                    b.Property<int>("SubCategoryId");

                    b.Property<string>("UINumber");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int>("WarrantyType");

                    b.HasKey("SINum");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.Premium", b =>
                {
                    b.Property<int>("PremiumID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<int>("ConfigID");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DealerID");

                    b.Property<int>("Duration");

                    b.Property<bool>("IsDeleted");

                    b.Property<float>("PremiumPercentage");

                    b.Property<int>("ProductSubGroupID");

                    b.Property<int>("ProgramID");

                    b.Property<string>("Remarks");

                    b.Property<int>("SINum");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<float>("ValidTo");

                    b.Property<int>("WarrantyTypeID");

                    b.HasKey("PremiumID");

                    b.ToTable("Premium");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.ProcessClaim", b =>
                {
                    b.Property<int>("ClaimCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualClaimAmount");

                    b.Property<string>("ActualInvoiceAmt");

                    b.Property<string>("ArigPaidAmountUSD");

                    b.Property<string>("ArigRejection");

                    b.Property<string>("ArigRejectionCode");

                    b.Property<int>("BranchCode");

                    b.Property<int>("ClaimFrom");

                    b.Property<string>("ClaimNo");

                    b.Property<int>("ConfigID");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CurrencyCode");

                    b.Property<DateTime>("CustomerInvoiceDate");

                    b.Property<string>("CustomerInvoiceNo");

                    b.Property<DateTime>("CustomerInvoiceReceivedOn");

                    b.Property<DateTime>("DateOfFailure");

                    b.Property<string>("DeductableAmount");

                    b.Property<float>("ExchangeRate");

                    b.Property<int>("FYCode");

                    b.Property<DateTime>("FaxReceivedDate");

                    b.Property<string>("FaxReceivedTime");

                    b.Property<string>("IUD");

                    b.Property<string>("InspectionNo");

                    b.Property<string>("Inspector");

                    b.Property<string>("InspectorComments");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("IsFirstAboveCover");

                    b.Property<string>("IsInspectionDone");

                    b.Property<string>("IsSPR");

                    b.Property<string>("LaborCostAftDisc");

                    b.Property<string>("LabourCharges");

                    b.Property<float>("LabourDiscountPer");

                    b.Property<DateTime>("LastServiceDate");

                    b.Property<string>("Legal");

                    b.Property<string>("MajorFaultCode");

                    b.Property<int>("OldClaimCode");

                    b.Property<float>("OtherDiscountPer");

                    b.Property<string>("OverLimitReasonDesc");

                    b.Property<string>("PartsCostAftDisc");

                    b.Property<int>("PayeeID");

                    b.Property<string>("PolicyCode");

                    b.Property<string>("ReasonForRejectionHold");

                    b.Property<int>("ReasonInspNotDone");

                    b.Property<string>("Remarks");

                    b.Property<string>("RepairerComments");

                    b.Property<int>("RepairerID");

                    b.Property<string>("RequestedAmount");

                    b.Property<string>("SPDetails");

                    b.Property<string>("ServiceCharges");

                    b.Property<float>("ServiceDiscountPer");

                    b.Property<float>("TaxPer");

                    b.Property<string>("TaxValue");

                    b.Property<string>("TotalClaimAmount");

                    b.Property<string>("TotalLabourCost");

                    b.Property<float>("TotalOtherDiscount");

                    b.Property<string>("TotalPartsCost");

                    b.Property<string>("TotalServiceCost");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ClaimCode");

                    b.ToTable("ProcessClaim");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.ProcessClaimDetail", b =>
                {
                    b.Property<int>("ProcessClaimDetailID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActualCost");

                    b.Property<int>("ClaimCode");

                    b.Property<string>("Comments");

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("FaultCode");

                    b.Property<string>("FinalCost");

                    b.Property<string>("Inspection");

                    b.Property<string>("InspectionNo");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("IsInspectionDone");

                    b.Property<string>("IsService");

                    b.Property<string>("LaborCost");

                    b.Property<float>("LaborDisPer");

                    b.Property<float>("MfgDisPer");

                    b.Property<string>("OtherCost");

                    b.Property<int>("PartCategory");

                    b.Property<int>("PartCode");

                    b.Property<int>("PartSRNumber");

                    b.Property<string>("Remarks");

                    b.Property<float>("RepairerDisPer");

                    b.Property<string>("ServiceDisPerc");

                    b.Property<string>("Total");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("ProcessClaimDetailID");

                    b.ToTable("ProcessClaimDetail");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("UserCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimApprovalLimit");

                    b.Property<string>("Email");

                    b.Property<int>("IUD");

                    b.Property<int>("LastModifiedBy");

                    b.Property<DateTime>("LastModifiedDateTime");

                    b.Property<int>("OldUserID");

                    b.Property<int>("PasswordExpiryInDays");

                    b.Property<string>("PersonName");

                    b.Property<int>("RoleCode");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPassword");

                    b.HasKey("UserCode");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.UserFilter", b =>
                {
                    b.Property<int>("UserFilterID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("EventAccess");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Remarks");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserRoleID");

                    b.HasKey("UserFilterID");

                    b.ToTable("UserFilter");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.UserRole", b =>
                {
                    b.Property<int>("UserRoleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Remarks");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserRoleName");

                    b.HasKey("UserRoleID");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("GwDealerPortal.DataAccess.Entities.WarrantyType", b =>
                {
                    b.Property<int>("WarrantyTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Remarks");

                    b.Property<int>("SINum");

                    b.Property<int?>("UpdatedById");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("WarrantyTypeName");

                    b.HasKey("WarrantyTypeID");

                    b.ToTable("WarrantyType");
                });
#pragma warning restore 612, 618
        }
    }
}