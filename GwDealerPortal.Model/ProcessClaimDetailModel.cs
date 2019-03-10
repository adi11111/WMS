using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GwDealerPortal.Model
{
    public class ProcessClaimDetailModel
    {
        public int ProcessClaimDetailID{ get; set; }
        public int ClaimCode { get; set; }
        public int PartCategory { get; set; }
        public int PartCode { get; set; }
        public int FaultCode { get; set; }
        public string Comments { get; set; }
        public string ActualCost { get; set; }
        public string OtherCost { get; set; }
        public float MfgDisPer { get; set; }
        public string FinalCost { get; set; }
        public float RepairerDisPer { get; set; }
        public string Total { get; set; }
        public string IsInspectionDone { get; set; }
        public string InspectionNo { get; set; }
        public string Inspection { get; set; }
        public string IsService { get; set; }
        public string ServiceDisPerc { get; set; }
        public string LaborCost { get; set; }
        public float LaborDisPer { get; set; }
        public string IUD { get; set; }
        public int ClaimDtlId { get; set; }
        public int PartSRNumber { get; set; }
        public string Remarks { get; set; }
    }
}
