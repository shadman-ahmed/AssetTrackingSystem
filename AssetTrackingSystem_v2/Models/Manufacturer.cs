using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        
        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9]{3,3}$", ErrorMessage = " Code must be exactly 3 digits long, alphabetic, capital, with no space in between")]
        public string Code { get; set; }

        public string Description { get; set; }

        public List<Model> Models { get; set; }
    }
}