using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class ClaimStatusModel
    {
        public int ClaimCode { get; set; }
        public int ClaimStatus { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
        public int IUD { get; set; }
        public float AutoID { get; set; }
        public string StatusCode { get; set; }
    }
}
