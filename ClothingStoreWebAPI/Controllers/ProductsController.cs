using ClothingStoreWebAPI.Data;
using ClothingStoreWebAPI.Entities;
using ClothingStoreWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductsController : ControllerBase
	{
		private ClothingStoreContext _context;
		public ProductsController(ClothingStoreContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Product>> GetAllProduct()
		{
			var product = _context.Products;
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpGet("{id}")]
		public ActionResult<Product> GetProductById(int id) {

			var product = _context.Products.FirstOrDefault(a => a.ProductId == id );
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpGet("name = {name}")]
		public ActionResult<Product> GetProductByName(string name) {
			var product = _context.Products.FirstOrDefault(a => a.Name == name);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpPost]
		public ActionResult<Product> AddProduct(Product product) {

			var new_product = new Product()
			{
				Name = product.Name,
				Color = product.Color,
				Brand = product.Brand,
				Description = product.Description,
				CategoryId = product.CategoryId,
				ImageURL = product.ImageURL,
				Price = product.Price,
				QuantityInStock = product.QuantityInStock,
				Size = product.Size,
			};
			_context.Products.Add(new_product);
			_context.SaveChanges();
			return Ok(product);
		}

		[HttpPut("{id}")]
		public ActionResult<Product> PutProduct(Product product,int id) {

			var productToEdit = _context.Products.FirstOrDefault(a => a.ProductId == id);
			if (productToEdit == null)
			{
				return NotFound();
			}
			productToEdit.Name = product.Name;
			productToEdit.Color = product.Color;
			productToEdit.Brand = product.Brand;
			productToEdit.Description = product.Description;
			productToEdit.CategoryId = product.CategoryId;
			productToEdit.ImageURL = product.ImageURL;
			productToEdit.Price = product.Price;
			productToEdit.QuantityInStock = product.QuantityInStock;
			productToEdit.Size = product.Size;

			_context.SaveChanges();
			return Ok(product);
		}
	}
}
