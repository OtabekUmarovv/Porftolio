using ForApiProject.Domain.Entities.Employees;
using ForApiProject.Domain.Entities.Products;
using ForApiProject.Domain.Entities.Purchases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Data.Contexts
{
    public class MarketDBContext : DbContext
    {
        public MarketDBContext(DbContextOptions<MarketDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Purchase> Purchases { get; set; }

        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

    }
}
