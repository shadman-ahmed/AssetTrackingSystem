using AssetTrackingSystem_v2.Models;
using ATS.DAL.Base;
using ATS.Model.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AssetTrackingSystem_v2.DB;

namespace ATS.DAL
{
    public class GeneralCategoryRepository : BaseRepository<GeneralCategory>, IGeneralCategoryRepository, IDisposable
    {
        public AssetTrackingManagementDbContext Context
        {
            get { return _db as AssetTrackingManagementDbContext; }
        }

        public GeneralCategoryRepository():base(new AssetTrackingManagementDbContext())
        {

        }

        public GeneralCategoryRepository(DbContext db) : base(db)
        {
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
