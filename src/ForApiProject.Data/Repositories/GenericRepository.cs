using ForApiProject.Data.Contexts;
using ForApiProject.Data.IRepositories;
using ForApiProject.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Auditable
    {
        protected readonly MarketDBContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(MarketDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, string include = null, bool isTracking = true)
        {
            IQueryable<T> query = expression is null ? _dbSet : _dbSet.Where(expression);

            if(!string.IsNullOrEmpty(include))
                query = query.Include(include);

            if (!isTracking)
                query.AsNoTracking();

            return query;
         }

        public async Task<T> CreateAsync(T entity)
            => (await _dbSet.AddAsync(entity)).Entity;

        public async Task<T> UpdateAsync(T entity)
            => _dbSet.Update(entity).Entity;

        
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression = null, string include = null)
            => await GetAll(expression, include).FirstOrDefaultAsync();

        
        public async Task DeleteAsync(T entity)
            => _dbSet.Remove(entity);

        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
