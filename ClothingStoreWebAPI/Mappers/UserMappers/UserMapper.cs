using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Mappers.OrderMappers;
using ClothingStoreWebAPI.Models;

namespace ClothingStoreWebAPI.Mappers.UserMappers
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
		}
	}
}
