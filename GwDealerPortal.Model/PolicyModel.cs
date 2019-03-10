using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.Model
{
    public class PolicyModel
    {
        public int SINum { get; set; }
        public string PolNumber { get; set; }
        public string ClientRefNum { get; set; }
        public int DealerID { get; set; }
        public string DealerName { get; set; }
        public string DocNumber { get; set; }
        public string IssueDate { get; set; }
        public string CustName { get; set; }
        public string MobileNum { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductGroup { get; set; }
        public int ProductSubGroupId { get; set; }
        public string ProductSubGroupName { get; set; }
        public int ManuDuration { get; set; }
        public string ManuCutoff { get; set; }
        public int ExtDuration { get; set; }
        public string ExtCutoff { get; set; }
        public string ClaimLimit { get; set; }
        //public string Status { get; set; }
        public string StartDate { get; set; }
        public string ExpiryDate { get; set; }
        public string SoldBy { get; set; }
        public string SoldDate { get; set; }
        public string Remarks { get; set; }
        public string ManuExpiryDate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategory { get; set; }
        public float ProductPrice { get; set; }
        public string Size { get; set; }
        public string SizeRange { get; set; }
        public string UINumber { get; set; }
        public float Discount { get; set; }
        public float Premium { get; set; }
        public float PremiumPercentage { get; set; }
        public int ProgramID { get; set; }
        public int LocationCode { get; set; }
        //public int Duration { get; set; }
        public int WarrantyTypeID { get; set; }
    }
}
