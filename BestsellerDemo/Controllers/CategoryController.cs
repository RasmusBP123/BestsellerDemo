using BestsellerDemo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BestsellerDemo.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var categories = _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetStockForCategory(string categoryId)
        {
            var stockCount = _categoryRepository.GetStockForCategory(categoryId);
            return Ok(stockCount);
        }
    }
}
