using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class CCRange : BaseEntity
    {
        [Key]
        public int CCRangeID { get; set; }
        public string CCRangeName { get; set; }
        public int ConfigID { get; set; }
    }
}
