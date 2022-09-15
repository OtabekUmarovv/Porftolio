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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Category> AddAsync(CategoryForCreationDto dto)
        {
            Category mappedCategory = _mapper.Map<Category>(dto);

            var Category = await _unitOfWork.Categories.CreateAsync(mappedCategory);

            await _unitOfWork.SaveChangesAsync();
            
            return Category;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression)
        {
            var exist = await _unitOfWork.Categories.GetAsync(expression);

            if (exist is null)
                throw new Exception("Category not found");

            await _unitOfWork.Categories.DeleteAsync(exist);
            await _unitOfWork.Categories.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params, Expression<Func<Category, bool>> expression = null)
            => _unitOfWork.Categories.GetAll(expression,isTracking: false).ToPagedList(@params).ToList();

       
        public async Task<Category> GetAsync(Expression<Func<Category, bool>> expression = null)
            => await _unitOfWork.Categories.GetAsync(expression);

        public async Task<Category> UpdateAsync(long id, CategoryForCreationDto dto)
        {
            var exist = await _unitOfWork.Categories.GetAsync(p => p.Id == id);
            
            if(exist is null)
            {
                throw new Exception("Category not found");
            }

            var mappedCategory = _mapper.Map(dto, exist);

            var updatedCategory = await _unitOfWork.Categories.UpdateAsync(mappedCategory);
            await _unitOfWork.SaveChangesAsync();

            return updatedCategory;
        }
    }
}
