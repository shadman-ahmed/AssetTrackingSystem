using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Model.Models
{
    public class PurchaseAttachments
    {
        public int Id { get; set; }

        public int PurchaseHeaderId { get; set; }

        public byte[] FileData { get; set; }
    }
}
