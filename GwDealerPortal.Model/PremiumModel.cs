using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class PremiumModel
    {
        public int SINum{ get; set; }
        public int PremiumID{ get; set; }
        public int DealerID { get; set; }
        public int ProductSubGroupID { get; set; }
        public int CateogoryID { get; set; }
        public int ConfigID { get; set; }
        public int ProgramID { get; set; }
        public int Duration { get; set; }
        public int WarrantyTypeID { get; set; }
        public float PremiumPercentage { get; set; }
        public DateTime ValidFrom{ get; set; }
        public float ValidTo { get; set; }
        public string Remarks{ get; set; }
    }
}
