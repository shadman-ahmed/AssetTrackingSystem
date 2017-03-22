using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.ViewModels
{
    public class PurchaseCreateVM
    {
        public int Id { get; set; }
        
        /* Purchase Header */
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Vendor")]
        public int VendorId { get; set; }
        
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        /* Purchase Attachment */
        public string FilePath { get; set; }

        /* Purchase Details */
        public int PurchaseHeaderId { get; set; }
        
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        [Display(Name = "Model")]
        public int ModelId { get; set; }

        [Display(Name = "Manufacturer Code")]
        public string ManufacturerCode { get; set; }

        [Display(Name = "Model Code")]
        public string ModelCode { get; set; }

        public int Quantity { get; set; }
        [Display(Name = "Unit Price")]
        public long UnitPrice { get; set; }

        [Display(Name = "Warranty Period")]
        public int WarrantyPeriod { get; set; }

        public int WarrantyUnitId { get; set; }

        [Display(Name = "Has Warranty")]
        public bool HasWarranty { get; set; }
    }
}