using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class Location : BaseEntity
    {
        public int SINum { get; set; }
        [Key]
        public int LocationCode { get; set; }
        public string LocationName { get; set; }
        public int WEMSLocationCode { get; set; }
    }
}
