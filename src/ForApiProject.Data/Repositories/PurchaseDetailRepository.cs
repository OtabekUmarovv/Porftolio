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
    public class PurchaseDetailRepository : GenericRepository<PurchaseDetail>, IPurchaseDetailRepository
    {
        public PurchaseDetailRepository(MarketDBContext dbContext) : base(dbContext)
        {
        }
    }
}
