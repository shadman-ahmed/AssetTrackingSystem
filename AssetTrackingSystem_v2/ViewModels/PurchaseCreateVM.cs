using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.ViewModels
{
    public class PurchaseCreateVM
    {
        public int Id { get; set; }
        
        /* Purchase Header */
        public DateTime PurchaseDate { get; set; }

        public int VendorId { get; set; }
        
        public string PurchasedBy { get; set; }

        public DateTime EntryDate { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        /* Purchase Attachment */
        public string FilePath { get; set; }

        /* Purchase Details */
        public int PurchaseHeaderId { get; set; }

        public int CategoryId { get; set; }

        public int Quantity { get; set; }

        public long UnitPrice { get; set; }

        public int WarrantyPeriod { get; set; }

        public int WarrantyUnitId { get; set; }

        public bool HasWarranty { get; set; }
    }
}