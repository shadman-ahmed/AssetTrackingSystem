﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public Manufacturer Manufacturer { get; set; }

        [Display(Name = "Manufacturer")]
        [Required]
        public int ManufacuturerId { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }
    }
}