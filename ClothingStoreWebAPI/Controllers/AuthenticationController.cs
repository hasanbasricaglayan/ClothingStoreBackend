using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks.Dataflow;
using ClothingStoreWebAPI.Data;
using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Mappers.UserMappers;
using ClothingStoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
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
		private IUserMapper _userMapper;

		public AuthenticationController(IConfiguration configuration, ClothingStoreContext context, IUserMapper userMapper)
		{
			_configuration = configuration;
			_context = context;
			_userMapper = userMapper;
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
			var role = "client";
			if (user.IsAdmin)
			{
				role = "admin";
			}
			List<Claim> claimsForToken =
			[
				new Claim("sub", user.UserId.ToString()),
				new Claim("firstname", user.FirstName),
				new Claim("lastname", user.LastName),
				new Claim("emailAddress",user.Email),
				new Claim("role", role),
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

		[Authorize]
		[HttpGet("auth")]
		public ActionResult<UserDTO> GetUserByToken()
		{
			string? userEmail = User.Claims.FirstOrDefault(u => u.Type == "emailAddress")?.Value;

			User? user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

			if (user == null)
			{
				return NotFound();
			}

			UserDTO userDTO = _userMapper.UserToDTO(user);

			return Ok(userDTO);
		}

		[Authorize]
		[HttpGet("role")]
		public ActionResult<bool> GetRoleByToken()
		{
			//Console.WriteLine(User.ToString);
			var role = User.Claims.FirstOrDefault(u => u.Type == "role" || u.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
			var isAdmin = false;
			if (role == "admin")
			{
				isAdmin = true;
			}
			Console.WriteLine(isAdmin);
			//UserDTO userDTO = _userMapper.UserToDTO(user);
			return Ok(isAdmin);
		}
	}
}
