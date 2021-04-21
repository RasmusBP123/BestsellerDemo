using Microsoft.AspNetCore.Mvc;

namespace BestsellerDemo.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IDataAccess _dataAccess;

        public CategoryController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var categories = _dataAccess.Categories;
            return Ok(categories);
        }
    }
}
