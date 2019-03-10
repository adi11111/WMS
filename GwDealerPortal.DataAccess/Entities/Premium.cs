using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class Premium : BaseEntity
    {
        [Key]
        public int SINum { get; set; }
        public int PremiumID { get; set; }
        public int DealerID { get; set; }
        public int ProductSubGroupID { get; set; }
        public int OurCutOff { get; set; }
        public int ManuCutOff { get; set; }
        public int CCRangeID { get; set; }
        public int ClaimLimitID { get; set; }
        public int CategoryID { get; set; }
        public int ConfigID { get; set; }
        public int ProgramID { get; set; }
        // Extended duration id coming from duration table
        public int DurationID { get; set; }
        public int ManuDuration { get; set; }
        public int LocationCode { get; set; }
        public int WarrantyTypeID { get; set; }
        //[ForeignKey("WarrantyTypeID")]
        //public WarrantyType WarrantyType { get; set; }
        public float PremiumAmount { get; set; }
        public DateTime ValidFrom { get; set; }
        public float ValidTo { get; set; }
        //[ForeignKey("ConfigID")]
        //public Config Config { get; set; }
    }
}
