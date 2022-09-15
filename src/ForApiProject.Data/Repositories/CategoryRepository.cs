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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MarketDBContext dbContext) : base(dbContext)
        {
        }
    }
}
