using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem_v2.Models
{
    public class AssetRegistration
    {
        public int Id { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Location Location { get; set; }

        public int LocationId { get; set; }

        public bool IsFromPurchase { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }
    }
}
