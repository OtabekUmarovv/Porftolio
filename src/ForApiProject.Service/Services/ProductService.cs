using AutoMapper;
using ForApiProject.Data.IRepositories;
using ForApiProject.Domain.Entities.Products;
using ForApiProject.Service.DTOs;
using ForApiProject.Service.Helpers;
using ForApiProject.Service.Interfaces;
using ForApiProjectDomain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Service.Services
{
    public class ProductService : IProductService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> AddAsync(ProductForCreationDto dto)
        {
            Product mappedProduct = _mapper.Map<Product>(dto);

            var product = await _unitOfWork.Products.CreateAsync(mappedProduct);

            await _unitOfWork.SaveChangesAsync();
            
            return product;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression)
        {
            var exist = await _unitOfWork.Products.GetAsync(expression);

            if (exist is null)
                throw new Exception("Product not found");

            await _unitOfWork.Products.DeleteAsync(exist);
            await _unitOfWork.Products.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null)
            => _unitOfWork.Products.GetAll(expression,isTracking: false).ToPagedList(@params).ToList();

        public async Task<IEnumerable<Product>> GetAllWithCategoryAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null)
            => _unitOfWork.Products.GetAll(expression, "Category", false).ToPagedList(@params).ToList();

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> expression = null)
            => await _unitOfWork.Products.GetAsync(expression);

        public async Task<Product> UpdateAsync(long id, ProductForCreationDto dto)
        {
            var exist = await _unitOfWork.Products.GetAsync(p => p.Id == id);
            
            if(exist is null)
            {
                throw new Exception("Product not found");
            }

            var mappedProduct = _mapper.Map(dto, exist);

            var updatedProduct = await _unitOfWork.Products.UpdateAsync(mappedProduct);
            await _unitOfWork.Products.SaveChangesAsync();

            return updatedProduct;
        }
    }
}
