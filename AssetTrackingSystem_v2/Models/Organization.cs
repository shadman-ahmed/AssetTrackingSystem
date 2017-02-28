using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AssetTrackingSystem_v2.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string ShortName { get; set; }

        public List<Branch> Branches;

    }
}