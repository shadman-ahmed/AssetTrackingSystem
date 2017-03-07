using ATS.Model.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem_v2.Models;
using System.Linq.Expressions;
using ATS.DAL;
using ATS.Model.Interfaces.DAL;

namespace ATS.BLL
{
    public class GeneralCategoryManager : IGeneralCategoryManager
    {

        private IGeneralCategoryRepository _repository;

        public GeneralCategoryManager()
        {
            _repository = new GeneralCategoryRepository();
        }

        public bool Add(GeneralCategory entity)
        {
            return _repository.Add(entity);
        }

        public ICollection<GeneralCategory> GetAll(Expression<Func<GeneralCategory, bool>> predicateExpression)
        {
            return _repository.GetAll(predicateExpression);
        }

        public GeneralCategory GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Remove(GeneralCategory entity)
        {
            return _repository.Remove(entity);
        }

        public bool Update(GeneralCategory entity)
        {
            return _repository.Update(entity);
        }
    }
}
