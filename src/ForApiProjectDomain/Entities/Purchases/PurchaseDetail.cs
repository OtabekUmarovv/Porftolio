using ForApiProject.Domain.Commons;
using ForApiProject.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Domain.Entities.Purchases
{
    public class PurchaseDetail : Auditable
    {
        public long PurchaseId { get; set; }

        [ForeignKey(nameof(PurchaseId))]
        public Purchase Purchase { get; set; }

        public long ProductId { get; set; }
        
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public int ProductQuantity { get; set; }
    }
}
