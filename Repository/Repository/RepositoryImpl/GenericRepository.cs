using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Repository;
using Util.Exceptions;

namespace Repository.RepositoryImpl
{
    public class GenericRepository<T> : IGenericRepository<T,int> where T : class
    {
        protected DbContext context;
        public GenericRepository(DbContext context){
            this.context = context;
        }

        public async Task<T> Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return entity;
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
            T entity = await context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new DoesNotExistException("Not exist");
            }
            else
            {
                return entity;
            }
        }

        public async Task<bool> Removed(int id)
        {
            T entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new DoesNotExistException("Not exist");
            }
            else
            {
                context.Set<T>().Remove(entity);
                return true;
            }
        }

        public async Task<T> Update(T entity)
        {
            await Task.Run(() => context.Set<T>().Update(entity));
            return entity;
        }
    }
}