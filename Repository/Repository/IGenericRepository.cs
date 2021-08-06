
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IGenericRepository<T,ID> where T : class
    {
         Task Add(T entity);
         void Removed(T entity);
         Task<T> GetById(ID id);
         Task<IEnumerable<T>> GetAll();
         Task<IEnumerable<T>> Find(Expression<Func<T,bool>> predicate);
         
    }
}