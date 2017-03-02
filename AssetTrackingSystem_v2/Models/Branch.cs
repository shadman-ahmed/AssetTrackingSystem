using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.Models
{
    public class Branch
    {

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[^\\s]+[A-Z]*$", ErrorMessage = "Only uppercase letters allowed with no empty space")]
        public string ShortName { get; set; }


        [StringLength(50)]
        public string Code { get; set; }    /* <OrganizationShortName>_<BranchShortName> */
        public Organization Organization { get; set; }

        [Display(Name = "Organization")] 
        [Required]
        public int OrganizationId { get; set; }

    }
}