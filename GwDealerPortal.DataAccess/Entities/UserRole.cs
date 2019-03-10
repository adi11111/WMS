using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
   public class UserRole:BaseEntity
    {
        public int UserRoleID { get; set; }
        public string UserRoleName { get; set; }
    }
}
