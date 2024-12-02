using System.Security.Claims;
using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Models;

namespace ClothingStoreBackend.Services.AuthenticationServices
{
	public interface IAuthenticationService
	{
		Task<User?> Authenticate(LoginModel loginModel);
		string GenerateJwtToken(string issuer, string audience, string secret, List<Claim> claims);
	}
}
