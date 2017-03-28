using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.ViewModels
{
    public class AssetRegistrationVM
    {
        public int Id { get; set; }

        [Display(Name = "Date From")]
        public DateTime PurchaseDateFrom { get; set; }

        [Display(Name = "To")]
        public DateTime PurchaseDateTo { get; set; }

        [Display(Name = "General Category")]
        public int GeneralCategoryId { get; set; }

        [Display(Name = "Product Category Code")]
        public string Code { get; set; }

        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Product Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Model")]
        public int ModelId { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Price")]
        public long UnitPrice { get; set; }

        [Display(Name = "Date")]
        public DateTime PurchaseDate { get; set; }
    }
}