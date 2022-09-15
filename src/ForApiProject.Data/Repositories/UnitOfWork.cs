using ForApiProject.Data.Contexts;
using ForApiProject.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Categories { get; }

        public IEmployeeRepository Employees { get; }

        public IProductRepository Products { get; }

        public IPurchaseDetailRepository PurchaseDetails { get; }

        public IPurchaseRepository Purchases { get; }

        public MarketDBContext dbContext;

        public UnitOfWork(MarketDBContext context)
        {
            this.dbContext = context;

            Categories = new CategoryRepository(context);

            Employees = new EmployeeRepository(context);

            Products = new ProductRepository(context);

            PurchaseDetails = new PurchaseDetailRepository(context);

            Purchases = new PurchaseRepository(context);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
