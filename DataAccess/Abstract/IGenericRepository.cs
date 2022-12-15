using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericRepository<T> where T: class
    {
        List<T> GetAll();
        T GetById(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Update(T entity);
        void Delete(Expression<Func<T, bool>> expression);
    }
}