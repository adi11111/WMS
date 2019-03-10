using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class SequenceDetailModel
    {
        public int SINum { get; set; }
        public string SequenceType { get; set; }
        public int DealerID{ get; set; }
        public int SubGroupID{ get; set; }
        public float SequenceNumber { get; set; }
    }
}
