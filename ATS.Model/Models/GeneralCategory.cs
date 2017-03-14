using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.Models
{
    public class GeneralCategory
    {
        public int Id { get; set; }

        [Display(Name = "General Category")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Display(Name = "Short Name")]
        [Required]
        [StringLength(150)]
        [Index(IsUnique = true)]
        [RegularExpression(@"^[A-Z]{2,2}$", ErrorMessage = "<ul><li>Only uppercase characters are allowed</li><li>Short Name must be 2 character long</li></ul>")]
        public string ShortName { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public List<Category> Categories { get; set; }

    }
}