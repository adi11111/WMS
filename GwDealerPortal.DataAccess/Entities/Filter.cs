using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{  
    public class Filter : BaseEntity
    {
        [Key]
        public int FilterID { get; set; }
        public int FilterTypeID { get; set; }
        public int UserRoleID { get; set; }
        public int? UserID { get; set; }
        public int? EventAccessID { get; set; }
        public int FilterTypeValue { get; set; }
    }
}
