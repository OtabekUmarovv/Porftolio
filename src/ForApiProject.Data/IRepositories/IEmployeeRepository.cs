using ForApiProject.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.IRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
