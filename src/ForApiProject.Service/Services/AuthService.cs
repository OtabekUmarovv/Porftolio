using ForApiProject.Data.IRepositories;
using ForApiProject.Service.Interfaces;
using ForApiProjectDomain.Enums;
using ForApiProjectDomain.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ForApiProject.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        public async Task<string> GenerateTokenAsync(string login, string password)
        {
            var employee = await unitOfWork.Employees.GetAsync(x =>
            x.Login == login && x.Password == password && x.State != ItemState.Deleted);
            if (employee is null)
                throw new MarketException(400, "Login or password is incorrect");

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("Id", employee.Id.ToString()),
                new Claim(ClaimTypes.Role, employee.Position.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
