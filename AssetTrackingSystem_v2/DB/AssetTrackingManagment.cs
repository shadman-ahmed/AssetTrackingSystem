using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AssetTrackingSystem_v2.Models;

namespace AssetTrackingSystem_v2.DB
{
    public class AssetTrackingManagment : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
}