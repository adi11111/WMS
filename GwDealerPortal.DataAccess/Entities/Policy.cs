using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class Policy : BaseEntity
    {
        [Key]
        public int SINum { get; set; }

        public int PolNumber { get; set; }
        public string ClientRefNum { get; set; }
        public int DealerID { get; set; }
        public string DealerName { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string DocNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public string CustomerName { get; set; }
        public string MobileNum { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductGroup { get; set; }
        public int ProductSubGroupId { get; set; }
        public string ProductSubGroupName { get; set; }
        public int ManuDuration { get; set; }
        public string ManuCutoff { get; set; }
        public int ExtDurationID { get; set; }
        public string ExtCutoff { get; set; }
        public int Status { get; set; }
        public string ClaimLimit { get; set; }
        //public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string SoldBy { get; set; }
        public DateTime? SoldDate { get; set; }
        public DateTime? ManuExpiryDate { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int ModelYearId { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public float ProductPrice { get; set; }
        public string Size { get; set; }
        public string SizeRange { get; set; }
        public string UINumber { get; set; }
        public float Discount { get; set; }
        public float Premium { get; set; }
        public float PremiumPercentage { get; set; }
        public int ProgramID { get; set; }
        public int LocationCode { get; set; }
        public int? CC { get; set; }
        public float? CurrentMileage { get; set; }

        public int CCRangeId { get; set; }
        public string Capacity { get; set; }
        public string CapacityRange { get; set; }
        public string RegNumber { get; set; }
        public DateTime? RegDate { get; set; }
        public string PlateType { get; set; }
        public int WarrantyType { get; set; }
        public int ConfigID { get; set; }
        public string RefNumber { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Description { get; set; }
        //  public int Duration { get; set; }

        //[ForeignKey("DealerID")]
        //public virtual Dealer Dealer { get; set; }
        //[ForeignKey("ProgramID")]
        //public virtual Program Program { get; set; }
        //[ForeignKey("LocationCode")]
        //public virtual Location Location { get; set; }
        //[ForeignKey("ProductSubGroupId")]
        //public virtual ProductSubGroup ProductSubGroup { get; set; }
    }
}
