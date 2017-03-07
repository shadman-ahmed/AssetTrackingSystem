using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem_v2.Models;
using ATS.DAL;
using ATS.Model.Interfaces;
using ATS.Model.Interfaces.BLL;

namespace ATS.BLL
{
    public class OrganizationManager : IOrganizationManager
    {
        private IOrganizationRepository _repository;

        public OrganizationManager()
        {
            _repository = new OrganizationRepository();
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
