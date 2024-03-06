using ClothingStoreWebAPI.Data;
using ClothingStoreWebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CategoriesController : ControllerBase
	{
		private ClothingStoreContext _context;
		public CategoriesController(ClothingStoreContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Category>> GetAllCategory()
		{
			var categories = _context.Categories;
			if (categories == null)
			{
				return NotFound();
			}
			return Ok(categories);
		}

		[HttpGet("{id}")]
		public ActionResult<IEnumerable<Category>> GetProductByCategory(int id)
		{
			var product = _context.Products.Where(a => a.CategoryId == id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}
	}
}
