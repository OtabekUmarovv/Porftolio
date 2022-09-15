using ForApiProject.Domain.Entities.Employees;
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
    public interface IEmployeeService
    {
        Task<Employee> AddAsync(EmployeeForCreationDto dto);
        Task<Employee> UpdateAsync(long id, EmployeeForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Employee, bool>> expression);
        Task<Employee> GetAsync(Expression<Func<Employee, bool>> expression);
        Task<IEnumerable<Employee>> GetAllAsync(PaginationParams @params, Expression<Func<Employee, bool>> expression = null);

    }
}
