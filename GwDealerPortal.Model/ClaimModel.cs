using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class ClaimModel
    {
        public ClaimModel() { }
        public int ClaimCode { get; set; }
        public int PolicyCode { get; set; }
        public int ClaimNumber { get; set; }
        public DateTime DateOfFailure { get; set; }
        public int ClaimBranch { get; set; }
        public string JobCardNo { get; set; }
        public int Workshop { get; set; }
        public bool MfgAssistance { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string PartCategory { get; set; }
        public string Part { get; set; }
        public string Fault { get; set; }
        public decimal PartCost { get; set; }
        public string MfgDisc { get; set; }
        public string RepDisc { get; set; }
        public decimal LabourCost { get; set; }
        public string LabDisc { get; set; }
        public decimal Total { get; set; }
        public string FaultRemarks { get; set; }
        public DateTime LastServiceDate { get; set; }
        public int LastServiceMileage { get; set; }
        public string ServiceProofDetails { get; set; }
        public int BreakdownMileage { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime EnteredOn { get; set; }
        public decimal AuthorizedAmount { get; set; }
        public string GwAuthNo { get; set; }
        public int AuthorizedBy { get; set; }
        public decimal DeductableAmount { get; set; }
        public string Remarks { get; set; }
        public DateTime AuthorisedOn { get; set; }
        public int Status { get; set; }


        public int ParameterCode { get; set; }
        public string ParameterValue { get; set; }
        public string LastServiceDetails { get; set; }
        public string LastClaimDetails { get; set; }
        // public List<IFormFile> Files { get; set; }
    }
}
