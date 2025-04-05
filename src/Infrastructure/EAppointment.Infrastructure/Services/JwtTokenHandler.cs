using EAppointment.Application.Abstractions.Services;
using EAppointment.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EAppointment.Infrastructure.Services
{
    internal sealed class JwtTokenHandler(IConfiguration _configuration) : IJwtTokenHandler
    {
        public string CreateToken(User user)
        {
            Claim[]? claims =
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim("UserName", user.UserName ?? string.Empty),
            ];

            DateTime expire = DateTime.Now.AddDays(1);

            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_configuration["JwtToken:SecurityKey"] ?? string.Empty));
            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _configuration["JwtToken:Issuer"],
                audience: _configuration["JwtToken:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: expire,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler handler = new();
            return handler.WriteToken(jwtSecurityToken);
        }
    }
}
