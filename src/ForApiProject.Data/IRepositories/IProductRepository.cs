using ForApiProject.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
