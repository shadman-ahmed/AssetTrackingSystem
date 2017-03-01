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
        public List<Model> Models { get; set; }
    }
}