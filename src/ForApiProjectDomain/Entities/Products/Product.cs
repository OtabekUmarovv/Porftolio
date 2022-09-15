using ForApiProject.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Domain.Entities.Products
{
    public class Product : Auditable
    {
        [MaxLength(64)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int Aksiya { get; set; } = 0;
        
        public long CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
