using ForApiProject.Domain.Commons;
using ForApiProject.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Domain.Entities.Purchases
{
    public class Purchase : Auditable
    {
        public long EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public decimal TotalAmount { get; set; } = 0;

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }

}
