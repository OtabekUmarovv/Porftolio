
using ForApiProject.Domain.Entities.Products;
using ForApiProject.Service.DTOs;
using ForApiProject.Service.Interfaces;
using ForApiProjectDomain.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace ForApiProject.API.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllAsync([FromQuery] PaginationParams @params)
        {
            return await _productService.GetAllWithCategoryAsync(@params);
        }

        [HttpGet("{Id}")]
        public async Task<Product> GetAsync([FromRoute(Name = "Id")] long id)
        {
            return await _productService.GetAsync(p => p.Id == id);
        }

        [HttpPut("{Id}")]
        public async Task<Product> UpdateAsync([FromQuery(Name = "Id")] long id, ProductForCreationDto dto)
        {
            return await _productService.UpdateAsync(id, dto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery(Name = "Id")] long id)
        {
            await _productService.DeleteAsync(p => p.Id == id);
            return NoContent();
        } 

        [HttpPost]
        public async Task<Product> AddAsync(ProductForCreationDto dto)
        {
            return await _productService.AddAsync(dto);
        }

        [HttpPost("Categories")]
        public async Task<Category> AddCategoryAsync([FromBody] CategoryForCreationDto dto)
        {
            var category = await _categoryService.AddAsync(dto);

            return category;
        }

        [HttpGet("Categories")]
        public async Task<IEnumerable<Category>> GetAllCategoryAsync([FromQuery]PaginationParams @params)
        {
            var categories = await _categoryService.GetAllAsync(@params);

            return categories;
        }

        [HttpDelete("Categories/{Id}")]
        public async Task<ActionResult> DeleteCategoryAsync([FromRoute(Name = "Id")] long id)
        {

            await _categoryService.DeleteAsync(p => p.Id == id);
            return NoContent();
        }

    }
}











