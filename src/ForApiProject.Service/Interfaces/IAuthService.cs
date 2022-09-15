using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Service.Interfaces
{
    public interface IAuthService 
    {
        Task<string> GenerateTokenAsync(string login, string password);
    }
}
