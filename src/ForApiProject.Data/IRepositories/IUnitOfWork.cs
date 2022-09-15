using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IEmployeeRepository Employees { get; }
        IProductRepository Products { get; }
        IPurchaseDetailRepository PurchaseDetails { get; }
        IPurchaseRepository Purchases { get; }

        Task SaveChangesAsync();    
    }
}
