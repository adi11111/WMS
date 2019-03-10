using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class ClaimServiceDetailModel
    {
        public int ClaimCode { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterValue { get; set; }
        public string LastServiceDetails { get; set; }
        public string LastClaimDetails { get; set; }
        public string IUD { get; set; }
        public int ID { get; set; }
    }
}
