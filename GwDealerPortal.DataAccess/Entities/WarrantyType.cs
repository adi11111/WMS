using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class WarrantyType : BaseEntity
    {
        public int SINum{ get; set; }
        [Key]
        public int WarrantyTypeID { get; set; }
        public string WarrantyTypeName{ get; set; }
    }
}
