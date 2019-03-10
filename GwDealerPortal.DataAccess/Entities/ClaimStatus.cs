using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
   public class ClaimsStatus
    {
        [Key]
        public int SlNumber { get; set; }
        public int ClaimCode { get; set; }
        public int ClaimStatus { get; set; }
        [ForeignKey("ClaimCode")]
        public virtual ProcessClaim ProcessClaim { get; set; }
    }
}
