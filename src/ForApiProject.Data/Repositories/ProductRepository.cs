using ForApiProject.Data.Contexts;
using ForApiProject.Data.IRepositories;
using ForApiProject.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MarketDBContext dbContext) : base(dbContext)
        {
        }
    }
}
