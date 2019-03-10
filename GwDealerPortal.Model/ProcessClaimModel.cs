using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class ProcessClaimModel
    {
        public int ClaimCode { get; set; }
        public string ClaimNo { get; set; }
        public int PolicyCode { get; set; }
        public DateTime FaxReceivedDate { get; set; }
        public string FaxReceivedTime { get; set; }
        public int ClaimFrom { get; set; }
        public int RepairerID { get; set; }
        public string RepairerComments { get; set; }
        public int CurrencyCode { get; set; }
        public string RequestedAmount { get; set; }
        public string IsSPR { get; set; }
        public DateTime DateOfFailure { get; set; }
        public DateTime LastServiceDate { get; set; }
        public string DeductableAmount { get; set; }
        public string TotalPartsCost { get; set; }
        public float LabourDiscountPer { get; set; }
        public string LabourCharges { get; set; }
        public string TotalLabourCost { get; set; }
        public float OtherDiscountPer { get; set; }
        public float TotalOtherDiscount { get; set; }
        public string TotalClaimAmount { get; set; }
        public string ServiceCharges { get; set; }
        public float ServiceDiscountPer { get; set; }
        public string TotalServiceCost { get; set; }
        public string ReasonForRejectionHold { get; set; }
        public string CustomerInvoiceNo { get; set; }
        public DateTime CustomerInvoiceDate { get; set; }
        public DateTime CustomerInvoiceReceivedOn { get; set; }
        public string ActualClaimAmount { get; set; }
        public int ConfigID { get; set; }
        public int FYCode { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int LastModifiedBy { get; set; }
        public float ExchangeRate { get; set; }
        public string IsInspectionDone { get; set; }
        public string InspectionNo { get; set; }
        public string Inspector { get; set; }
        public string InspectorComments { get; set; }
        public string SPDetails { get; set; }
        public string ActualInvoiceAmt { get; set; }
        public string TaxValue { get; set; }
        public float TaxPer { get; set; }
        public int PayeeID { get; set; }
        public int ReasonInspNotDone { get; set; }
        public int OldClaimCode { get; set; }
        public string IUD { get; set; }
        public string PartsCostAftDisc { get; set; }
        public string LaborCostAftDisc { get; set; }
        public string MajorFaultCode { get; set; }
        public string OverLimitReasonDesc { get; set; }
        public string Legal { get; set; }
        public int BranchCode { get; set; }
        public string IsFirstAboveCover { get; set; }
        public string ArigRejection { get; set; }
        public string ArigRejectionCode { get; set; }
        public string ArigPaidAmountUSD { get; set; }
        public string Remarks { get; set; }
        public List<ProcessClaimDetailModel> ProcessClaimDetails { get; set; }
    }
}
