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
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null);

        Task<IEnumerable<Product>> GetAllWithCategoryAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null);

        Task<Product> GetAsync(Expression<Func<Product, bool>> expression = null);

        Task<Product> AddAsync(ProductForCreationDto dto);

        Task<Product> UpdateAsync(long id, ProductForCreationDto dto);

        Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression);

    }
}
