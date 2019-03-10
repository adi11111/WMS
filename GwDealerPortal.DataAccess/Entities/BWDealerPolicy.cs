using System;
using System.Collections.Generic;
using System.Text;

namespace GwDealerPortal.DataAccess.Entities
{

    public class BWDealerPolicy : BaseEntity
    {
        public int ID { get; set; }
        public string PolicyNumber { get; set; }
        public string ClientRefNumber { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string DealerName { get; set; }
        public string ProductType { get; set; }
        public string ProductCategory { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public string UIN { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal GrossPremiumPercentage { get; set; }
        public decimal GrossPremium { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int ManufacturerWarrantyDuration { get; set; }
        public DateTime ManufacturerWarrantyStartDate { get; set; }
        public DateTime ManufacturerWarrantyEndDate { get; set; }
        public string ExtendedWarrantyType { get; set; }
        public int ExtendedWarrantyDuration { get; set; }
        public DateTime ExtendedWarrantyStartDate { get; set; }
        public DateTime ExtendedWarrantyEndDate { get; set; }
        public string SalesMan { get; set; }
    }

}
