using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class Program : BaseEntity
    {
        [Key]
        public int SINum { get; set; }
        public int ProgramID { get; set; }
        public string ProgramName { get; set; }
    }
}
