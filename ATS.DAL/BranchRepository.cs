using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem_v2.DB;
using AssetTrackingSystem_v2.Models;
using ATS.DAL.Base;
using ATS.Models.Interfaces.DAL;

namespace ATS.DAL
{
    public class BranchRepository : BaseRepository<Branch>, IDisposable, IBranchRepository
    {
        public AssetTrackingManagementDbContext Context
        {
            get { return _db as AssetTrackingManagementDbContext; }
        }

        public BranchRepository() :  base(new AssetTrackingManagementDbContext())
        {
            
        }
        public BranchRepository(DbContext db) : base(db)
        {
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
