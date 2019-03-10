using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class DealerBranch : BaseEntity
    {
        [Key]
        public int DealerBranchID { get; set; }
        public string DealerBranchName { get; set; }
        public int DealerID { get; set; }
        [ForeignKey("DealerID")]
        public virtual Dealer Dealer{ get; set; }
    }
}
