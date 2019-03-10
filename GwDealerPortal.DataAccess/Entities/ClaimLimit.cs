using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class ClaimLimit : BaseEntity
    {
        [Key]
        public int ClaimLimitID { get; set; }
        public string ClaimLimitName { get; set; }
        public int ProductSubGroupID { get; set; }
        public int DealerID { get; set; }
    }
}
