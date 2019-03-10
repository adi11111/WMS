using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class BaseEntity
    {
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
    }
}
