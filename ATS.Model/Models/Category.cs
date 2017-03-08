using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{3,3}$", ErrorMessage = "<ul><li>Only uppercase characters are allowed</li><li>Short Name must be 3 character long</li></ul>")]
        public string ShortName { get; set; }
        public string Code { get; set; }    /* <GeneralCategory Short Name>_<Category Short Name> */

        [StringLength(150)]
        public string Description { get; set; }
        public GeneralCategory GeneralCategory { get; set; }

        [Display(Name = "General Category")]
        public int GeneralCategoryId { get; set; }

    }
}