using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Models;

namespace ClothingStoreBackend.Mappers.UserMappers
{
	public interface IUserMapper
	{
		UserDTO UserToDTO(User user);
		List<UserDTO> UsersToDTO(IEnumerable<User> users);

		User UserFromDTO(UserDTO userDTO);
		List<User> UsersFromDTO(IEnumerable<UserDTO> usersDTO);

		void UpdateUser(User user, UserDTO userDTO);
	}
}
