using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem_v2.Models;
using ATS.DAL;
using ATS.Model.Interfaces.BLL;
using ATS.Model.Interfaces.DAL;

namespace ATS.BLL
{
    public class LocationManager:ILocationManager
    {
        private ILocationRepository _repository;

        public LocationManager()
        {
            _repository = new LocationRepository();
        }
        public bool Add(Location entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Location entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Location entity)
        {
            throw new NotImplementedException();
        }

        public Location GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Location> GetAll(Expression<Func<Location, bool>> predicateExpression)
        {
            throw new NotImplementedException();
        }
    }
}
