using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Repository;

namespace Repository.RepositoryImpl
{
    public class GenericRepository<T> : IGenericRepository<T,int> where T : class
    {
        protected DbContext context;
        public GenericRepository(DbContext context){
            this.context = context;
        }

        public async Task<bool> Add(T entity)
        {
             await context.Set<T>().AddAsync(entity);
             return true;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Removed(int id)
        {
            T entity = await context.Set<T>().FindAsync(id);
            context.Set<T>().Remove(entity);
            return true;
        }
    }
}