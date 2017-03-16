using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem_v2.Models
{
    public class PurchaseDetails
    {
        public int Id { get; set; }

        public int PurchaseHeaderId { get; set; }

        public int CategoryId { get; set; }

        public int Quantity { get; set; }

        public long UnitPrice { get; set; }

        public int WarrantyPeriod { get; set; }

        public int WarrantyUnitId { get; set; }

        public bool HasWarranty { get; set; }
    }
}
