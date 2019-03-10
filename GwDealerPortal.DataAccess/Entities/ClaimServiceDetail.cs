using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class ClaimServiceDetail : BaseEntity
    {
        [Key]
        public int ClaimServiceDetailID { get; set; }
        public int ClaimCode { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterValue { get; set; }
        public string LastServiceDetails { get; set; }
        public string LastClaimDetails { get; set; }
        [ForeignKey("ClaimCode")]
        public virtual ProcessClaim ProcessClaim { get; set; }
        //[ForeignKey("ParameterCode")]
        //public virtual Parameter Parameter { get; set; }
    }
}
