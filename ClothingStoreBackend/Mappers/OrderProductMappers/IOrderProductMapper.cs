using ClothingStoreBackend.Entities;
using ClothingStoreBackend.Models;

namespace ClothingStoreBackend.Mappers.OrderProductMappers
{
	public interface IOrderProductMapper
	{
		OrderProductDTO OrderProductToDTO(OrderProduct orderProduct);
		List<OrderProductDTO> OrderProductsToDTO(IEnumerable<OrderProduct> orderProducts);

		OrderProduct OrderProductFromDTO(OrderProductDTO orderProductDTO);
		List<OrderProduct> OrderProductsFromDTO(IEnumerable<OrderProductDTO> orderProductsDTO);
	}
}
