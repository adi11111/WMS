using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class DealerModel
    {
        public int DealerCode { get; set; }
        public string DealerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int SubGroupCode { get; set; }
        public string SalesPhoneNo { get; set; }
        public string SaleFaxNo { get; set; }
        public string ServiceContactPerson { get; set; }
        public string AccountPhoneNo { get; set; }
        public string AccountFaxNo { get; set; }
        public string AccountContactNo { get; set; }
        public string AccountContactPerson { get; set; }
        public int AccGroupCode { get; set; }
        public int OldLedgerCode { get; set; }
        public int LedgerCode { get; set; }
        public string IsSelfAuthorityLimit { get; set; }
        public string SelfAuthorityLimit { get; set; }
        public string DeductableValue { get; set; }
        public int NoOfInstalments { get; set; }
        public string IsActive { get; set; }
        public DateTime DeactivationDate { get; set; }
        public int ConfigID { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int LastModifiedBy { get; set; }
        public int OldDealerCode { get; set; }
        public string IUD { get; set; }
        public int PrivateSale { get; set; }
        public float BWPremiumPerc { get; set; }
    }
}
