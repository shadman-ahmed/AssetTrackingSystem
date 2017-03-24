using AssetTrackingSystem_v2.Models;
using ATS.DAL;
using ATS.Models.Interfaces.BLL;
using ATS.Models.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ATS.BLL
{
    public class ManufacturerManager : IManufacturerManager
    {
        private IManufacturerRepository _repository;

        public ManufacturerManager()
        {
            _repository = new ManufacturerRepository();
        }
        public bool Add(Manufacturer entity)
        {
            return _repository.Add(entity);
        }

        public bool Remove(Manufacturer entity)
        {
            return _repository.Remove(entity);
        }

        public bool Update(Manufacturer entity)
        {
            return _repository.Update(entity);
        }

        public Manufacturer GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ICollection<Manufacturer> GetAll(Expression<Func<Manufacturer, bool>> predicateExpression)
        {
            return _repository.GetAll(predicateExpression);
        }

        public Manufacturer Get(Expression<Func<Manufacturer, bool>> predicate)
        {

            return _repository.Get(predicate);
        }
    }
}
