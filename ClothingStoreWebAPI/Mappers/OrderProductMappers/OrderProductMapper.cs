using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Mappers.ProductMappers;
using ClothingStoreWebAPI.Models;

namespace ClothingStoreWebAPI.Mappers.OrderProductMappers
{
	public class OrderProductMapper : IOrderProductMapper
	{
		private IProductMapper _productMapper;

		public OrderProductMapper(IProductMapper productMapper)
		{
			_productMapper = productMapper;
		}

		public OrderProductDTO OrderProductToDTO(OrderProduct orderProduct)
		{
			OrderProductDTO orderProductDTO = new OrderProductDTO
			{
				OrderId = orderProduct.OrderId,
				ProductId = orderProduct.ProductId,
				Product = _productMapper.ProductToDTO(orderProduct.Product!),
				Quantity = orderProduct.Quantity,
				Price = orderProduct.Price,
			};

			return orderProductDTO;
		}

		public List<OrderProductDTO> OrderProductsToDTO(IEnumerable<OrderProduct> orderProducts)
		{
			List<OrderProductDTO> orderProductsDTO = [];

			foreach (OrderProduct orderProduct in orderProducts)
			{
				OrderProductDTO orderProductDTO = OrderProductToDTO(orderProduct);
				orderProductsDTO.Add(orderProductDTO);
			}

			return orderProductsDTO;
		}

		public OrderProduct OrderProductFromDTO(OrderProductDTO orderProductDTO)
		{
			return new OrderProduct
			{
				OrderId = orderProductDTO.OrderId,
				ProductId = orderProductDTO.ProductId,
				Quantity = orderProductDTO.Quantity,
				Price = orderProductDTO.Price,
			};
		}

		public List<OrderProduct> OrderProductsFromDTO(IEnumerable<OrderProductDTO> orderProductsDTO)
		{
			List<OrderProduct> orderProducts = [];

			foreach (OrderProductDTO orderProductDTO in orderProductsDTO)
			{
				OrderProduct orderProduct = OrderProductFromDTO(orderProductDTO);
				orderProducts.Add(orderProduct);
			}

			return orderProducts;
		}
	}
}
