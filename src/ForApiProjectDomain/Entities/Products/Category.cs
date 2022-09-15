using ForApiProject.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Domain.Entities.Products
{
    public class Category : Auditable
    {
        [MaxLength(64)]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public int QQS { get; set; } = 0;

        public virtual ICollection<Product> Products { get; set; }
    }
}
