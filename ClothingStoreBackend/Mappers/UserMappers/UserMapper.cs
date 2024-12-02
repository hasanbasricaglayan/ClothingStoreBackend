using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Mappers.OrderMappers;
using ClothingStoreBackend.Models;

namespace ClothingStoreBackend.Mappers.UserMappers
{
	public class UserMapper : IUserMapper
	{
		private IOrderMapper _orderMapper;

		public UserMapper(IOrderMapper orderMapper)
		{
			_orderMapper = orderMapper;
		}

		public UserDTO UserToDTO(User user)
		{
			UserDTO userDTO = new UserDTO
			{
				UserId = user.UserId,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				Email = user.Email,
				Password = user.Password,
				DateOfBirth = user.DateOfBirth,
				BillingAddress = user.BillingAddress,
				DeliveryAddress = user.DeliveryAddress,
				IsAdmin = user.IsAdmin
			};

			List<OrderDTO> ordersDTO = _orderMapper.OrdersToDTO(user.Orders);
			userDTO.Orders = ordersDTO;

			return userDTO;
		}

		public List<UserDTO> UsersToDTO(IEnumerable<User> users)
		{
			List<UserDTO> usersDTO = [];

			foreach (User user in users)
			{
				UserDTO userDTO = UserToDTO(user);
				usersDTO.Add(userDTO);
			}

			return usersDTO;
		}

		public User UserFromDTO(UserDTO userDTO)
		{
			User user = new User
			{
				UserId = userDTO.UserId.GetValueOrDefault(),
				FirstName = userDTO.FirstName,
				LastName = userDTO.LastName,
				PhoneNumber = userDTO.PhoneNumber,
				Email = userDTO.Email,
				Password = userDTO.Password,
				DateOfBirth = userDTO.DateOfBirth,
				BillingAddress = userDTO.BillingAddress,
				DeliveryAddress = userDTO.DeliveryAddress,
				IsAdmin = userDTO.IsAdmin
			};

			List<Order> orders = _orderMapper.OrdersFromDTO(userDTO.Orders);
			user.Orders = orders;

			return user;
		}

		public List<User> UsersFromDTO(IEnumerable<UserDTO> usersDTO)
		{
			List<User> users = [];

			foreach (UserDTO userDTO in usersDTO)
			{
				User user = UserFromDTO(userDTO);
				users.Add(user);
			}

			return users;
		}

		public void UpdateUser(User user, UserDTO userDTO)
		{
			user.UserId = user.UserId;
			user.FirstName = userDTO.FirstName;
			user.LastName = userDTO.LastName;
			user.PhoneNumber = userDTO.PhoneNumber;
			user.Email = userDTO.Email;
			user.Password = userDTO.Password;
			user.DateOfBirth = userDTO.DateOfBirth;
			user.BillingAddress = userDTO.BillingAddress;
			user.DeliveryAddress = userDTO.DeliveryAddress;
			user.IsAdmin = userDTO.IsAdmin;
			user.Orders = user.Orders;
		}
	}
}
