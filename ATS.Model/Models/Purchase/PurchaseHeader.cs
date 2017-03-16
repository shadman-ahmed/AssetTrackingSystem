using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem_v2.Models
{
    public class PurchaseHeader
    {
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int VendorId { get; set; }

        [StringLength(250)]
        public string PurchasedBy { get; set; }

        public DateTime EntryDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
