using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Model.Models
{
    public class PurchaseDetails
    {
        public int Id { get; set; }

        [Required]
        public int PurchaseHeaderId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int WarrantyPeriod { get; set; }

        public int WarrantyUnitId { get; set; }

        public bool HasWarranty { get; set; }
    }
}
