using System.Security.Claims;
using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Models;
using ClothingStoreBackend.Services.AuthenticationServices;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreBackend.Controllers
{
	[Route("api")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private IConfiguration _configuration;
		private IAuthenticationService _authenticationService;

		public AuthenticationController(IConfiguration configuration, IAuthenticationService authenticationService)
		{
			_configuration = configuration;
			_authenticationService = authenticationService;
		}

		[HttpPost("login")]
		public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
		{
			User? user = await _authenticationService.Authenticate(loginModel);
			if (user == null)
			{
				return Unauthorized();
			}

			List<Claim> claims =
			[
				new Claim("sub", user.UserId.ToString()),
				new Claim("firstname", user.FirstName),
				new Claim("lastname", user.LastName),
				new Claim("email",user.Email),
				new Claim("admin", user.IsAdmin.ToString())
			];

			string token = _authenticationService.GenerateJwtToken(
				_configuration["Authentication:Issuer"]!,
				_configuration["Authentication:Audience"]!,
				_configuration["Authentication:SecretForKey"]!,
				claims);

			return Ok(token);
		}
	}
}
