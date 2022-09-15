using ForApiProject.Data.Contexts;
using ForApiProject.Data.IRepositories;
using ForApiProject.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MarketDBContext dbContext) : base(dbContext)
        {
        }
    }
}
