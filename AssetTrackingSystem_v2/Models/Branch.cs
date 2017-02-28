using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.Models
{
    public class Branch
    {

        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        [Required]
        [RegularExpression("^[A-Z]$")]
        public string ShortName { get; set; }
        public string Code { get; set; }    /* <OrganizationShortName>_<BranchShortName> */
        public Organization Organization { get; set; }

        [Display(Name = "Organization")] 
        [Required]
        public int OrganizationId { get; set; }

    }
}