using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Model.Models
{
    public class PurchaseDetailsSerialNo
    {
        public int Id { get; set; }

        [Required]
        public int SerialNo { get; set; }

        [Required]
        public int PurchaseDetailsId { get; set; }
        
    }
}
