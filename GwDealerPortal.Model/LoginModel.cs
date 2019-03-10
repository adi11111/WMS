using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class LoginModel
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public int ProgramCode { get; set; }
        public int ConfigId { get; set; }
    }
}
