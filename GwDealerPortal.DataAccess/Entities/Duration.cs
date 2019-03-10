using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class Duration : BaseEntity
    {
        [Key]
        public int DurationID { get; set; }
        public string DurationName { get; set; }
        public int ProductSubGroupID { get; set; }
    }
}
