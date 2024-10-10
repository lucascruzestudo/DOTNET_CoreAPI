using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Constants;

namespace Project.Infrastructure.Authentication
{
    public class TokenService(IOptions<JwtSettings> jwtSettings, IRoleRepository roleRepository) : ITokenService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;
        private readonly IRoleRepository _roleRepository = roleRepository;

        public string GenerateToken(User user)
        {
            if (string.IsNullOrWhiteSpace(_jwtSettings.Secret))
            {
                throw new ArgumentException("JWT secret key is not configured.");
            }

            var role = _roleRepository.Get(r => r.Id == user.RoleId) ?? throw new ArgumentException("User role not found.");
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
