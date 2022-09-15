using ForApiProject.Data.Contexts;
using ForApiProject.Data.IRepositories;
using ForApiProject.Domain.Entities.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.Repositories
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MarketDBContext dbContext) : base(dbContext)
        {
        }
    }
}
