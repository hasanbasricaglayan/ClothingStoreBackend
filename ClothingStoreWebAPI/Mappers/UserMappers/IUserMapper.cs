using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Models;

namespace ClothingStoreWebAPI.Mappers.UserMappers
{
	public interface IUserMapper
	{
		UserDTO UserToDTO(User user);
		List<UserDTO> UsersToDTO(IEnumerable<User> users);

		User UserFromDTO(UserDTO userDTO);

		void UpdateUser(User user, UserDTO userDTO);
	}
}
