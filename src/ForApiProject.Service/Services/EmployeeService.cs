using AutoMapper;
using ForApiProject.Data.IRepositories;
using ForApiProject.Domain.Entities.Employees;
using ForApiProject.Service.DTOs;
using ForApiProject.Service.Helpers;
using ForApiProject.Service.Interfaces;
using ForApiProjectDomain.Configurations;
using ForApiProjectDomain.Enums;
using ForApiProjectDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Employee> AddAsync(EmployeeForCreationDto dto)
        {
            var employee = await unitOfWork.Employees.GetAsync(p =>
             p.Login.Equals(dto.Login) && p.State != ItemState.Deleted);
            if (employee is not null)
                throw new MarketException(400, "User already exist");

            // map entity
            var newEmployee = mapper.Map<Employee>(dto);

            newEmployee = await unitOfWork.Employees.CreateAsync(newEmployee);
            await unitOfWork.SaveChangesAsync();

            return newEmployee;
        }

        public async Task<Employee> UpdateAsync(long id, EmployeeForCreationDto dto)
        {
            // check for exist
            var employee = await unitOfWork.Employees.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (employee is null)
                throw new MarketException(404, "User not found");

            // check for exist already
            var existEmplpyee = await unitOfWork.Employees.GetAsync(p =>
                p.Login.Equals(dto.Login) && p.State != ItemState.Deleted);
            if (existEmplpyee is not null)
                throw new MarketException(400, "This login already exist");

            var mappedEmployee = mapper.Map(dto, employee);

            mappedEmployee.State = ItemState.Updated;
            mappedEmployee.UpdatedAt = DateTime.UtcNow;

            var updatedUser = await unitOfWork.Employees.UpdateAsync(mappedEmployee);

            await unitOfWork.SaveChangesAsync();

            return updatedUser;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Employee, bool>> expression)
        {
            // check for exist
            var employee = await unitOfWork.Employees.GetAsync(expression);
            if (employee is null)
                throw new MarketException(404, "User not found");

            employee.State = ItemState.Deleted;
            employee.UpdatedAt = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<Employee> GetAsync(Expression<Func<Employee, bool>> expression)
        {
            var employee = await unitOfWork.Employees.GetAsync(expression);
            if (employee is null)
                throw new MarketException(404, "User not found");

            return employee;
        }


        public async Task<IEnumerable<Employee>> GetAllAsync(PaginationParams @params, Expression<Func<Employee, bool>> expression = null)
        {
            var employees = unitOfWork.Employees.GetAll(expression, isTracking: false);

            return employees.ToPagedList(@params).ToList();
        }
    }
}
