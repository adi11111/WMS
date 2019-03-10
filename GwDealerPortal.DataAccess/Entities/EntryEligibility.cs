using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class EntryEligibility: BaseEntity
    {
        [Key]
        public int EntryEligibilityID { get; set; }
        public int ProductSubGroupID { get; set; }
        public int EntryMillage { get; set; }
        public int AgeLimit{ get; set; }
    }
}
