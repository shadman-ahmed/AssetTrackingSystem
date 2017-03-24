using ATS.Models.Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTrackingSystem_v2.Models;
using System.Linq.Expressions;
using ATS.Models.Interfaces.DAL;
using ATS.DAL;

namespace ATS.BLL
{
    public class ModelManager : IModelManager
    {


        private IModelRepository _repository;

        public ModelManager()
        {
            _repository = new ModelRepository();
        }

        public bool Add(Model entity)
        {
            return _repository.Add(entity);
        }

        public ICollection<Model> GetAll(Expression<Func<Model, bool>> predicateExpression)
        {
            return _repository.GetAll(predicateExpression);
        }

        public Model GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Remove(Model entity)
        {
            return _repository.Remove(entity);
        }

        public bool Update(Model entity)
        {
            int shortNameExist = _repository.GetAll(c => c.Id != entity.Id && c.Name == entity.Name).Count();

            if (shortNameExist > 0)
            {
                return false;
            }
            return _repository.Update(entity);
        }

        public Model Get(Expression<Func<Model, bool>> predicate)
        {

            return _repository.Get(predicate);
        }
    }
}
