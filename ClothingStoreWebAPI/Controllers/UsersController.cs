using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Mappers.UserMappers;
using ClothingStoreWebAPI.Models;
using ClothingStoreWebAPI.Services.UserRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private IUserRepository _userRepository;
		private IUserMapper _userMapper;

		public UsersController(IUserRepository userRepository, IUserMapper userMapper)
		{
			_userRepository = userRepository;
			_userMapper = userMapper;
		}

		// Admin
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsersWithOrdersAndProductsAsync()
		{
			IEnumerable<User> users = await _userRepository.GetAllUsersWithOrdersAndProductsAsync();

			List<UserDTO> usersDTO = _userMapper.UsersToDTO(users);

			return Ok(usersDTO);
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<UserDTO>> GetUserByIdWithOrdersAndProductsAsync(int userId)
		{
			User? user = await _userRepository.GetUserByIdWithOrdersAndProductsAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			UserDTO userDTO = _userMapper.UserToDTO(user);

			return Ok(userDTO);
		}

		// New user registration
		[HttpPost]
		public async Task<ActionResult<User>> AddUserAsync(UserDTO userDTO)
		{
			User user = _userMapper.UserFromDTO(userDTO);

			await _userRepository.AddUserAsync(user);
			await _userRepository.SaveChangesAsync();

			return Ok(user);
		}

		// Edit user's data
		[HttpPut("{userId}")]
		public async Task<ActionResult<User>> EditUserAsync(int userId, UserDTO userDTO)
		{
			User? user = await _userRepository.GetUserByIdAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			_userMapper.UpdateUser(user, userDTO);

			await _userRepository.SaveChangesAsync();

			return Ok(user);
		}

		// Delete user's account
		[HttpDelete("{userId}")]
		public async Task<ActionResult> DeleteUserAsync(int userId)
		{
			User? user = await _userRepository.GetUserByIdAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			_userRepository.DeleteUser(user);
			await _userRepository.SaveChangesAsync();

			return Ok();
		}
	}
}
