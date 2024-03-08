using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthentificationController : ControllerBase
	{
		private IConfiguration _configuration;

		public AuthentificationController(IConfiguration configuration)
		{
			_configuration = configuration;
		}


	}
}
