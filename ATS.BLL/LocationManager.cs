using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem_v2.Models;
using ATS.DAL;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.DAL;

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
            return _repository.Add(entity);
        }

        public bool Remove(Location entity)
        {
            return _repository.Remove(entity);
        }

        public bool Update(Location entity)
        {
            int shortNameExist = _repository.GetAll(c => c.Id != entity.Id && c.ShortName == entity.ShortName).Count();

            if (shortNameExist > 0)
            {
                return false;
            }
            return _repository.Update(entity);
        }

        public Location GetById(int id)
        {

            return _repository.GetById(id);
        }

        public ICollection<Location> GetAll(Expression<Func<Location, bool>> predicateExpression)
        {
            return _repository.GetAll(predicateExpression);
        }

        public Location Get(Expression<Func<Location, bool>> predicate)
        {

            return _repository.Get(predicate);
        }
    }
}
