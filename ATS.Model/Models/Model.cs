using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Display(Name = "Model")]
        [StringLength(150)]
        [Required]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [Display(Name = "Manufacturer")]
        [Required]
        public int ManufacturerId { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }
    }
}