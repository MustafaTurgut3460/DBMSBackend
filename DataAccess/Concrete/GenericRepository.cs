using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
         MyDbContext dbContext = new MyDbContext();

        public void Add(T entity)
        {
            
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            T deletedT = GetById(expression);

            if(deletedT != null)
            {
                dbContext.Set<T>().Remove(deletedT);
                dbContext.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public T GetById(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().FirstOrDefault(expression);
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }
    }
}