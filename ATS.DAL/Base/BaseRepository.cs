using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ATS.Model.Interfaces;

namespace ATS.DAL.Base
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;

        public BaseRepository(DbContext db)
        {
            _db = db;
        }

        public DbSet<T> Table
        {
            get { return _db.Set<T>(); }
        }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return _db.SaveChanges() > 0;
        }

        public bool Remove(T entity)
        {
            Table.Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            Table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public ICollection<T> GetAll(Expression<Func<T, bool>> predicateExpression)
        {
            return Table.Where(predicateExpression).ToList();
        }
    }
}
