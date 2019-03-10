using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class Interface : BaseEntity
    {   
        public int InterfaceID { get; set; }
        public int ParentInterfaceID { get; set; }
        public string InterfaceName { get; set; }
    }
}
