using ClothingStoreWebAPI.Data;
using ClothingStoreWebAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private ClothingStoreContext _context;
		public UsersController(ClothingStoreContext context)
		{
			_context = context;
		}


		[HttpGet]
		public ActionResult<IEnumerable<User>> GetAllUser()
		{
			var users = _context.Users.ToList();
			return Ok(users);
		}

		[HttpGet("{id}")]
		public ActionResult<User> GetUserById(int id)
		{

			var user = _context.Users.FirstOrDefault(a => a.UserId == id);
			if (user == null)
			{
				return NotFound();
			}
			return Ok(user);
		}

		[HttpPost]
		public ActionResult<User> PostUser(User user)
		{

			var newUser = new User()
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Password = user.Password,
				PhoneNumber = user.PhoneNumber,
				BillingAdress = user.BillingAdress,
				DateOfBirth = user.DateOfBirth,
				DeliveryAdress = user.DeliveryAdress,
				Orders = user.Orders,
				IsAdmin = false,
			};

			_context.Users.Add(newUser);
			_context.SaveChanges();
			return Ok(newUser);

		}

	}
}
