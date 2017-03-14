using AssetTrackingSystem_v2.Models;
using ATS.DAL.Base;
using ATS.Models.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AssetTrackingSystem_v2.DB;

namespace ATS.DAL
{
    public class ModelRepository : BaseRepository<Model>, IModelRepository, IDisposable
    {
        public AssetTrackingManagementDbContext Context
        {
            get { return _db as AssetTrackingManagementDbContext; }
        }

        public ModelRepository():base(new AssetTrackingManagementDbContext())
        {

        }
        public ModelRepository(DbContext db) : base(db)
        {
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
