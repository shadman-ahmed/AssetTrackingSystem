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
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression("^[A-Z0-9\\S]$", ErrorMessage = "Only uppercase letters and numbers are allowed with no empty space")]
        public string Code { get; set; }
        public List<Model> Models { get; set; }
    }
}