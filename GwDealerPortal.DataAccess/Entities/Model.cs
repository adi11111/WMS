using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class Model : BaseEntity
    {
        [Key]
        public int ModelID { get; set; }
        public string ModelName { get; set; }
    }
}
