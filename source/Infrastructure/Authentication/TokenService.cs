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
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IRoleRepository _roleRepository;

        public TokenService(IOptions<JwtSettings> jwtSettings, IRoleRepository roleRepository)
        {
            _jwtSettings = jwtSettings.Value;
            _roleRepository = roleRepository;
        }

        public string GenerateToken(User user)
        {
            if (string.IsNullOrWhiteSpace(_jwtSettings.Secret))
            {
                throw new ArgumentException("JWT secret key is not configured.");
            }

            var role = _roleRepository.Get(r => r.Id == user.RoleId);
            if (role == null)
            {
                throw new ArgumentException("User role not found.");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, role.Name)
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
