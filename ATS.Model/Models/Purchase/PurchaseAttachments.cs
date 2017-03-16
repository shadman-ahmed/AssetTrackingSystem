using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem_v2.Models
{
    public class PurchaseAttachments
    {
        public int Id { get; set; }

        public int PurchaseHeaderId { get; set; }

        [StringLength(250)]
        public string FilePath { get; set; }
    }
}
