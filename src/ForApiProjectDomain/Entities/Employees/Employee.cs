using ForApiProject.Domain.Commons;
using ForApiProject.Domain.Entities.Purchases;
using ForApiProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ForApiProject.Domain.Entities.Employees
{
    public class Employee : Auditable
    {
        [MaxLength(128)]
        public string FullName { get; set; }
        
        public int Age { get; set; }

        [MaxLength(32)]
        public string Phone { get; set; }

        [MaxLength(64)]
        public string Login { get; set; }

        [MaxLength(128)]
        public string Password { get; set; }

        public Gender Gender { get; set; }

        public Position Position { get; set; }
    }
}
