using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class FilterType : BaseEntity
    {
        [Key]
        public int FilterTypeID { get; set; }
        public string FilterTypeName { get; set; }

    }
}
