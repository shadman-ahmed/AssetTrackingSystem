using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem_v2.Models
{
    public class AssetRegistrationDetails
    {
        public int Id { get; set; }

        public AssetRegistration AssetRegistration { get; set; }

        public int AssetRegistrationId { get; set; }

        public PurchaseDetails PurchaseDetails { get; set; }

        public int PurchaseDetailsId { get; set; } // optional

        public Asset Asset { get; set; }

        public string AssetId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
