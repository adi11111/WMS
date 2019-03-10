using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class Make : BaseEntity
    {
        [Key]
        public int MakeID { get; set; }
        public string MakeName { get; set; }
    }
}
