using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [RegularExpression(@"^[A-Z0-9_]{0,10}$", ErrorMessage = "Only uppercase letters and numbers are allowed with no empty space")]
        public string ShortName { get; set; }

        public string Code { get; set; }    /* <BranchCode>_<Location ShortName> */

        public Organization Organization { get; set; }

        [Display(Name = "Organization")]
        [Required]
        public int OrganizationId { get; set; }

        public Branch Branch { get; set; }

        [Display(Name = "Branch")]
        [Required]
        public int BranchId { get; set; }

    }
}