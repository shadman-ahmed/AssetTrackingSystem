using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using AssetTrackingSystem_v2.DB;

namespace AssetTrackingSystem_v2.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Display(Name = "Location")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Display(Name = "Short Name")]
        [Required]
        [StringLength(150)]
        [Index(IsUnique = true)]
        [RegularExpression(@"^[A-Z0-9_]{0,10}$", ErrorMessage = "Only uppercase letters and numbers are allowed with no empty space")]
        public string ShortName { get; set; }

        [StringLength(150)]
        public string Code { get; set; }    /* <BranchCode>_<Location ShortName> */

        public Organization Organization { get; set; }

        [Display(Name = "Organization")]
        [Required]
        [CascadeDelete]
        public int OrganizationId { get; set; }

        public Branch Branch { get; set; }

        [Display(Name = "Branch")]
        [Required]
        [CascadeDelete]
        public int BranchId { get; set; }

    }
}