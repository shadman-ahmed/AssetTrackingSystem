using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetTrackingSystem_v2.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }    /* <OrganizationShortName>_<BranchShortName> */
        public Organization Organization { get; set; }
        public int Organization_Id { get; set; }

    }
}