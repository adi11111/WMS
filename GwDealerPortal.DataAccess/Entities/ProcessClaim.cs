using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class ProcessClaim : BaseEntity
    {
        [Key]
        public int ClaimCode { get; set; }
        public string ClaimNo { get; set; }
        public string PolicyCode { get; set; }
        public DateTime? FaxReceivedDate { get; set; }
        public DateTime? ClaimDate { get; set; }
        public string FaxReceivedTime { get; set; }
        public int? ClaimFrom { get; set; }
        public int? RepairerID { get; set; }
	    public string RepairerComments { get; set; }
        public int? CurrencyCode { get; set; }
        public decimal? RequestedAmount { get; set; }
        public string IsSPR { get; set; }
        public DateTime? DateOfFailure { get; set; }
        public DateTime? LastServiceDate { get; set; }
        public decimal? DeductableAmount { get; set; }
        public string TotalPartsCost { get; set; }
        public float? LabourDiscountPer { get; set; }
	    public string LabourCharges { get; set; }
        public string TotalLabourCost { get; set; }
        public float? OtherDiscountPer { get; set; }
        public float? TotalOtherDiscount { get; set; }
        public decimal? TotalClaimAmount { get; set; }
        public string ServiceCharges { get; set; }
        public float? ServiceDiscountPer { get; set; }
        public string TotalServiceCost { get; set; }
        public string ReasonForRejectionHold { get; set; }
        public string CustomerInvoiceNo { get; set; }
        public DateTime? CustomerInvoiceDate { get; set; }
        public DateTime? CustomerInvoiceReceivedOn { get; set; }
        public decimal? ActualClaimAmount { get; set; }
        public int? ConfigID { get; set; }
        public int? FYCode { get; set; }
        public float? ExchangeRate { get; set; }
        public string IsInspectionDone { get; set; }
        public string InspectionNo { get; set; }
        public string Inspector { get; set; }
        public string InspectorComments { get; set; }
        public string SPDetails { get; set; }
        public string ActualInvoiceAmt { get; set; }
        public string TaxValue { get; set; }
        public float? TaxPer { get; set; }
        public int? PayeeID { get; set; }
        public int? ReasonInspNotDone { get; set; }
        public int? OldClaimCode { get; set; }
        public string IUD { get; set; }
        public string PartsCostAftDisc { get; set; }
        public string LaborCostAftDisc { get; set; }
        public string MajorFaultCode { get; set; }
        public string OverLimitReasonDesc { get; set; }
        public string Legal { get; set; }
        public int? BranchCode { get; set; }
        public string IsFirstAboveCover { get; set; }
        public string ArigRejection { get; set; }
        public string ArigRejectionCode { get; set; }
        public decimal? ArigPaidAmountUSD { get; set; }
        public int? Status { get; set; }

        public int? ParameterCode { get; set; }
        public string ParameterValue { get; set; }
        public string LastServiceDetails { get; set; }
        public string LastClaimDetails { get; set; }

        public string JobCardNo { get; set; }
        public bool IsMfgAssistance { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public int? LastServiceMileage { get; set; }
        
        public decimal? TotalAmount { get; set; }
        public DateTime? EnteredOn { get; set; }
        public decimal? AuthorizedAmount { get; set; }
        public string GwAuthNo { get; set; }
        public int? AuthorizedBy { get; set; }
       
        public DateTime? AuthorisedOn { get; set; }
        public int? LastBreakdownMileage { get; set; }
    public virtual ICollection<ProcessClaimDetail> ProcessClaimDetail { get; set; }

        //[ForeignKey("PolicyCode")]
        //public virtual Policy Policy{ get; set; }

        //[ForeignKey("ConfigID")]
        //public virtual Config Config { get; set; }
        //[ForeignKey("ProductSubGroupId")]
        //public virtual ProductSubGroup ProductSubGroup { get; set; }
    }
}
