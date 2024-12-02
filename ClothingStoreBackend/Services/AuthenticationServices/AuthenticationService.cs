using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClothingStoreBackend.Data;
using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClothingStoreBackend.Services.AuthenticationServices
{
	public class AuthenticationService : IAuthenticationService
	{
		private ClothingStoreContext _context;

		public AuthenticationService(ClothingStoreContext context)
		{
			_context = context;
		}

		public async Task<User?> Authenticate(LoginModel loginModel)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
		}

		public string GenerateJwtToken(string issuer, string audience, string secret, List<Claim> claims)
		{
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
			SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
				issuer,
				audience,
				claims,
				DateTime.UtcNow,
				DateTime.UtcNow.AddHours(1),
				signingCredentials);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			string token = tokenHandler.WriteToken(jwtSecurityToken);

			return token;
		}
	}
}
