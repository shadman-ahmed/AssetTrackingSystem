using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem_v2.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public Organization Organization { get; set; }

        [Display(Name = "Organization")]
        [Required]
        public int OrganizationId { get; set; }

        public Branch Branch { get; set; }

        [Display(Name = "Branch")]
        [Required]
        public int BranchId { get; set; }


    }
}
