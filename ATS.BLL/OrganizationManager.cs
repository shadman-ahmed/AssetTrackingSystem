using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem_v2.Models;
using ATS.DAL;
using ATS.Models.Interfaces;
using ATS.Models.Interfaces.BLL;

namespace ATS.BLL
{
    public class OrganizationManager : IOrganizationManager
    {
        private IOrganizationRepository _repository;
        private IBranchManager _branchManager;

        public OrganizationManager()
        {
            _repository = new OrganizationRepository();
            _branchManager = new BranchManager();
        }
        public bool Add(Organization entity)
        {
            return _repository.Add(entity);
        }

        public bool Remove(Organization entity)
        {
            /* Removin associated branches of the organization */
            var branchList = _branchManager.GetAll(c => c.OrganizationId == entity.Id);

            if (branchList.Count > 0)
            {
                foreach (var branch in branchList)
                {
                    _branchManager.Remove(branch);
                }
            }
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

        public Organization Get(Expression<Func<Organization, bool>> predicate)
        {

            return _repository.Get(predicate);
        }
    }
}
