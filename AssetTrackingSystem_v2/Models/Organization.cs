using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AssetTrackingSystem_v2.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        [Key]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Key]
        [StringLength(50)]
        public string ShortName { get; set; }

    }
}