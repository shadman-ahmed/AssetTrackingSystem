using ATS.DAL;
using ATS.Model.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.BLL
{
    public class ManufacturerManager
    {
        private IManufacturerRepository _repository;

        public ManufacturerManager()
        {
            _repository = new ManufacturerRepository();
        }
        public bool Add(Organization entity)
        {
            return _repository.Add(entity);
        }

        public bool Remove(Organization entity)
        {
            return _repository.Remove(entity);
        }

        public bool Update(Organization entity)
        {
            return _repository.Update(entity);
        }

        public Organization GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ICollection<Organization> GetAll(Expression<Func<Organization, bool>> predicateExpression)
        {
            return _repository.GetAll(predicateExpression);
        }
    }
}
