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
    public class BranchManager : IBranchManager
    {
        private IBranchRepository _repository;

        public BranchManager()
        {
            _repository = new BranchRepository();
        }
        public bool Add(Branch entity)
        {
            return _repository.Add(entity);
        }

        public bool Remove(Branch entity)
        {
            return _repository.Remove(entity);
        }

        public bool Update(Branch entity)
        {
            int shortNameExist = _repository.GetAll(c => c.Id != entity.Id && c.ShortName == entity.ShortName).Count();

            if (shortNameExist > 0)
            {
                return false;
            }
            return _repository.Update(entity);
        }

        public Branch GetById(int id)
        {
            return _repository.GetById(id);
        }

        public ICollection<Branch> GetAll(Expression<Func<Branch, bool>> predicateExpression)
        {
            return _repository.GetAll(predicateExpression);
        }
    }
}
