using ForApiProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Service.DTOs
{
    public class EmployeeForCreationDto
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
    }
}
