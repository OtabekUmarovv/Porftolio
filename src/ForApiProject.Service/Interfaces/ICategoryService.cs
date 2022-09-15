using ForApiProject.Domain.Entities.Products;
using ForApiProject.Service.DTOs;
using ForApiProjectDomain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params, Expression<Func<Category, bool>> expression = null);

        Task<Category> GetAsync(Expression<Func<Category, bool>> expression = null);

        Task<Category> AddAsync(CategoryForCreationDto dto);

        Task<Category> UpdateAsync(long id, CategoryForCreationDto dto);

        Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression);
    }
}
