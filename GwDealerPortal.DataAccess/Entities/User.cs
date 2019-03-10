using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int UserCode{ get; set; }
        public string PersonName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int? PasswordExpiryInDays { get; set; }
        public int RoleCode { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int LastModifiedBy { get; set; }
        public int? OldUserID { get; set; }
        public string IUD { get; set; }
        public int DealerID { get; set; }
        public decimal? ClaimApprovalLimit { get; set; }
        public string Email { get; set; }
    }
}
