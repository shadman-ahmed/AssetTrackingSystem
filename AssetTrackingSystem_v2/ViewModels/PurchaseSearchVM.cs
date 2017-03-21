using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.ViewModels
{
    public class PurchaseSearchVM
    {
        public int Id { get; set; }

        [Display(Name = "General Category")]
        public int GeneralCategoryId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Model")]
        public int ModelId { get; set; }

        [Display(Name = "Vendor")]
        public int VendorId { get; set; }

        [Display(Name = "Warranty Period")]
        public int WarrantyPeriodFrom { get; set; }

        [Display(Name = "To")]
        public int WarrantyPeriodTo { get; set; }

        public int WarrantyUnitId { get; set; }

        [Display(Name = "Purchase Date From")]
        public DateTime PurchaseDateFrom { get; set; }

        [Display(Name = "To")]
        public DateTime PurchaseDateTo { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Price")]
        public long PriceFrom { get; set; }

        [Display(Name = "To")]
        public long PriceTo { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Price")]
        public long Price { get; set; }
    }
}