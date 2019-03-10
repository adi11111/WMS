using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class ModelYear : BaseEntity
    {
        [Key]
        public int ModelYearID { get; set; }
        public string ModelYearName { get; set; }
        public int ConfigID { get; set; }
    }
}
