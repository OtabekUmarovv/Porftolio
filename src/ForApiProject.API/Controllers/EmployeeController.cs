using ForApiProject.Domain.Entities.Employees;
using ForApiProject.Domain.Entities.Products;
using ForApiProject.Service.DTOs;
using ForApiProject.Service.Interfaces;
using ForApiProject.Service.Services;
using ForApiProjectDomain.Configurations;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ForApiProject.API.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllAsync([FromQuery] PaginationParams @params)
        {
            return await employeeService.GetAllAsync(@params);
        }

        [HttpGet("{Id}")]
        public async Task<Employee> GetAsync([FromRoute(Name = "Id")] long id)
        {
            return await employeeService.GetAsync(p => p.Id == id);
        }

        [HttpPut("{Id}")]
        public async Task<Employee> UpdateAsync([FromQuery(Name = "Id")] long id, EmployeeForCreationDto dto)
        {
            return await employeeService.UpdateAsync(id, dto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery(Name = "Id")] long id)
        {
            await employeeService.DeleteAsync(p => p.Id == id);
            return NoContent();
        }

        [HttpPost]
        public async Task<Employee> AddAsync(EmployeeForCreationDto dto)
        {
            return await employeeService.AddAsync(dto);
        }

    }
}
