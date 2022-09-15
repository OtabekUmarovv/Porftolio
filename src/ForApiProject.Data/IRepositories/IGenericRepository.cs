using ForApiProject.Data.Contexts;
using ForApiProject.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.IRepositories
{
    public interface IGenericRepository<T> 
        where T : Auditable
    {

        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, string include = null, bool isTracking = true);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> expression = null, string include = null);

        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
    }
}
