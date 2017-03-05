using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem_v2.DB;
using AssetTrackingSystem_v2.Models;
using ATS.DAL.Base;
using ATS.Model.Interfaces;

namespace ATS.DAL
{
    public class OrganizationRepository : BaseRepository<Organization>, IDisposable, IOrganizationRepository
    {
        public AssetTrackingManagementDbContext Context
        {
            get { return _db as AssetTrackingManagementDbContext; }
        }

        public OrganizationRepository():base(new AssetTrackingManagementDbContext())
        {
            
        }

        public OrganizationRepository(DbContext db) : base(db)
        {
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
