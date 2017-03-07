using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem_v2.DB;
using AssetTrackingSystem_v2.Models;
using ATS.DAL.Base;
using ATS.Model.Interfaces.DAL;

namespace ATS.DAL
{
    public class LocationRepository : BaseRepository<Location>, IDisposable, ILocationRepository
    {
        public AssetTrackingManagementDbContext Context { get { return _db as AssetTrackingManagementDbContext; } }   
        public LocationRepository(DbContext db) : base(db)
        {
        }

        public LocationRepository():base(new AssetTrackingManagementDbContext())
        {
            
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
