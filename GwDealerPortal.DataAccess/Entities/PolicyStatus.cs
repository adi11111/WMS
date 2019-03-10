using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class PolicyStatus
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string EmailText { get; set; }
    }
}
