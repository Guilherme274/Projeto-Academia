using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TrackFocus.Application.Service;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Infraestructure.Service
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            Claim[] claims = new[]
            {
              new Claim(ClaimTypes.NameIdentifier, user.Id),
              new Claim(ClaimTypes.Name, user.UserName),
              new Claim(ClaimTypes.DateOfBirth, user.DataNascimento.ToString()),
              new Claim(ClaimTypes.Role, "Admin")
            };

            var secret = _configuration["JwtSettings:Secret"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires : DateTime.Now.AddMinutes(10),
                signingCredentials: credentials,
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}