using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Mappers.UserMappers;
using ClothingStoreBackend.Models;
using ClothingStoreBackend.Services.UserRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreBackend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private IUserRepository _userRepository;
		private IUserMapper _userMapper;

		public UsersController(IUserRepository userRepository, IUserMapper userMapper)
		{
			_userRepository = userRepository;
			_userMapper = userMapper;
		}

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

		[HttpPost]
		public async Task<ActionResult<UserDTO>> AddUserAsync(UserDTO newUserDTO)
		{
			User user = _userMapper.UserFromDTO(newUserDTO);

			await _userRepository.AddUserAsync(user);
			await _userRepository.SaveChangesAsync();

			UserDTO userDTO = _userMapper.UserToDTO(user);

			return Ok(userDTO);
		}

		[HttpPut("{userId}")]
		public async Task<ActionResult<UserDTO>> UpdateUserAsync(int userId, UserDTO updatedUserDTO)
		{
			User? user = await _userRepository.GetUserByIdAsync(userId);
			if (user == null)
			{
				return NotFound();
			}

			_userMapper.UpdateUser(user, updatedUserDTO);
			await _userRepository.SaveChangesAsync();

			UserDTO userDTO = _userMapper.UserToDTO(user);

			return Ok(userDTO);
		}

		[HttpDelete("{userId}")]
		public async Task<IActionResult> DeleteUserAsync(int userId)
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
