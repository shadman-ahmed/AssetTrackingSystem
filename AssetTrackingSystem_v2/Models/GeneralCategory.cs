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

        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[A-Z\\S]$ {2,2}", ErrorMessage = "<ul><li>Only uppercase characters are allowed</li><li>Short Name must be 2 character long</li></ul>")]
        public string ShortName { get; set; }

        public string Description { get; set; }

        public List<Category> Categories { get; set; }

    }
}