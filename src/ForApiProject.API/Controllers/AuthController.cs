using ForApiProject.Service.DTOs;
using ForApiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForApiProject.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(EmployeeForLoginDto dto)
        {
            var token = await authService.GenerateTokenAsync(dto.Login, dto.Password);

            return Ok(new
            {
                Token = token
            });
        }
    }
}
