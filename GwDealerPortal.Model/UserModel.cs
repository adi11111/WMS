using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        

        public int UserCode { get; set; }
        public string PersonNmae { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string NewPassword { get; set; }
        public string Password { get; set; }
        public int PasswordExpiryInDays { get; set; }
        public int RoleCode { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int LastModifiedBy { get; set; }
        public int? OldUserID { get; set; }
        public string IUD { get; set; }
        public decimal? ClaimApprovalLimit { get; set; }
    }
}
