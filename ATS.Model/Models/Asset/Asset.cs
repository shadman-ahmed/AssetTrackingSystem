using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem_v2.Models
{
    public class Asset
    {
        public string Id { get; set; } //Asset ID format would be [GeneralCategoryCode][CategoryCode][6 digit numeric]

        public int AssetNo { get; set; }

        public Location Location { get; set; }

        [Display(Name = "Location")]
        public int LocationId { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Employee")]
        public int AssignTo { get; set; }   // EmployeeId

        public int SerialNo { get; set; }

    }
}
