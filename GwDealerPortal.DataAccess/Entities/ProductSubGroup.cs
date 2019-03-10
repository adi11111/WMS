using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class ProductSubGroup
    {
        [Key]
        public int SubGroupCode { get; set; }
        public int ProductGroupCode { get; set; }
        public string SubGroupName { get; set; }
        public int ReOrderLevel { get; set; }
        public float DefaultTransferFees { get; set; }
        public string TermsAndConditions { get; set; }
        public int ConfigID { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int LastModifiedBy { get; set; }
        public int OldPolicyTypeID { get; set; }
        public string IsPercentage { get; set; }
        public string IUD { get; set; }
        public int PolInputDaysLimitMin { get; set; }
        public int PolInputDaysLimitMax { get; set; }
        public int MISProgramType { get; set; }
        //[ForeignKey("ConfigID")]
        //public virtual Config Config { get; set; }
    }
}
