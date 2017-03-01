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
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression("^A-Z\\S$", ErrorMessage = "Only uppercase letters allowed with no empty space")]
        public string ShortName { get; set; }
        public string Code { get; set; }    /* <GeneralCategory Short Name>_<Category Short Name> */
        public GeneralCategory GeneralCategory { get; set; }

    }
}