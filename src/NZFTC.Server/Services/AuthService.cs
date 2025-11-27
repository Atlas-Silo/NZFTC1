// src/NZFTC.Server/Services/AuthService.cs
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NZFTC.Data.Entities;
using NZFTC.Shared.Dtos;
using NZFTC.Shared.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NZFTC.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<TokenResponseDto> LoginAsync(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.Username);
            if (user is null) return new TokenResponseDto { Token = string.Empty };

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded) return new TokenResponseDto { Token = string.Empty };

            var roles = (await _userManager.GetRolesAsync(user)).ToArray();

            var token = GenerateJwtToken(user, roles, out DateTime expiresAt);

            return new TokenResponseDto
            {
                Token = token,
                ExpiresAt = expiresAt,
                UserId = user.Id,
                Roles = roles
            };
        }

        public async Task RegisterAsync(RegisterDto register)
        {
            var user = new User { UserName = register.Username, Email = register.Email };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                var firstError = result.Errors.FirstOrDefault()?.Description ?? "Registration failed";
                throw new InvalidOperationException(firstError);
            }

            if (!string.IsNullOrWhiteSpace(register.Role))
            {
                await _userManager.AddToRoleAsync(user, register.Role);
            }
        }

        private string GenerateJwtToken(User user, string[] roles, out DateTime expiresAt)
        {
            var jwtSection = _configuration.GetSection("Jwt");
            var key = jwtSection["Key"] ?? throw new InvalidOperationException("Jwt:Key not configured");
            var issuer = jwtSection["Issuer"] ?? "NZFTC";
            var audience = jwtSection["Audience"] ?? "NZFTC";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            expiresAt = DateTime.UtcNow.AddHours(1);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            }.Concat(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}