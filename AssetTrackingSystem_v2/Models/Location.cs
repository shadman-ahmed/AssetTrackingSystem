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
        [RegularExpression("^[A-Z0-9]$", ErrorMessage = "Only uppercase letters allowed")]
        public string ShortName { get; set; }
        public string Code { get; set; }    /* <BranchCode>_<Location ShortName> */
    }
}