using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ClothingStoreWebAPI.Data;
using ClothingStoreWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api")]
	public class AuthenticationController : ControllerBase
	{
		private IConfiguration _configuration;
		private ClothingStoreContext _context;

		public AuthenticationController(IConfiguration configuration, ClothingStoreContext context)
		{
			_configuration = configuration;
			_context = context;

		}

		public class AuthenticationRequestBody
		{
			public string? Email { get; set; }
			public string? Password { get; set; }
		}

		private async Task<User?> UserLoginAsync(string? email, string? password)
		{
			User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

			return user;
		}

		private string GenerateJwtToken(User user)
		{
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Convert.FromBase64String(_configuration["Authentication:SecretForKey"]!));
			SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			List<Claim> claimsForToken =
			[
				new Claim("sub", user.UserId.ToString()),
				new Claim("firstname", user.FirstName),
				new Claim("lastname", user.LastName),
				new Claim("admin", user.IsAdmin.ToString())
			];

			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
				_configuration["Authentication:Issuer"],
				_configuration["Authentication:Audience"],
				claimsForToken,
				DateTime.UtcNow,
				DateTime.UtcNow.AddHours(1),
				signingCredentials);

			return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
		}

		[HttpPost("login")]
		public async Task<ActionResult> UserCredentialsAsync(AuthenticationRequestBody authenticationRequestBody)
		{
			User? user = await UserLoginAsync(authenticationRequestBody.Email, authenticationRequestBody.Password);

			if (user == null)
			{
				return Unauthorized();
			}

			return Ok(new { token = GenerateJwtToken(user) });
		}
	}
}
