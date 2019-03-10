using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class OtherService : BaseEntity
    {
        [Key]
        public int OtherServiceID { get; set; }
        public string OtherServiceName { get; set; }
        public float Amount { get; set; }
        public int BranchID { get; set; }
    }
}
