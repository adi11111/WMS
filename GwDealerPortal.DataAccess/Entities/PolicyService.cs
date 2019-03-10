using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class PolicyService 
    {
        [Key]
        public int PolicyServiceID { get; set; }
        public int PolicyID { get; set; }
        public int OtherServiceID { get; set; }
    }
}
