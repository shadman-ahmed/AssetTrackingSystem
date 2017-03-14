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
    public class CategoryManager : ICategoryManager
    {
        private ICategoryRepository _repository;

        public CategoryManager()
        {
            _repository = new CategoryRepository();
        }

        public bool Add(Category entity)
        {
            return _repository.Add(entity);
        }

        public ICollection<Category> GetAll(Expression<Func<Category, bool>> predicateExpression)
        {
            return _repository.GetAll(predicateExpression);
        }

        public Category GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Remove(Category entity)
        {
            return _repository.Remove(entity);
        }

        public bool Update(Category entity)
        {
            return _repository.Update(entity);
        }
    }
}
