using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Models;

namespace ClothingStoreWebAPI.Mappers.OrderProductMappers
{
	public interface IOrderProductMapper
	{
		OrderProductDTO OrderProductToDTO(OrderProduct orderProduct);
		List<OrderProductDTO> OrderProductsToDTO(IEnumerable<OrderProduct> orderProducts);

		OrderProduct OrderProductFromDTO(OrderProductDTO orderProductDTO);
		List<OrderProduct> OrderProductsFromDTO(IEnumerable<OrderProductDTO> orderProductsDTO);
	}
}
