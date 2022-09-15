using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Service.DTOs
{
    public class ProductForCreationDto
    {
        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public int Aksiya { get; set; }

        public long CategoryId { get; set; }
    }
}
