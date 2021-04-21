using BestsellerDemo.Entities;
using BestsellerDemo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BestsellerDemo.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IDataAccess _dataAccess;

        public ProductController(IProductRepository productRepository, IDataAccess dataAccess)
        {
            _productRepository = productRepository;
            _dataAccess = dataAccess;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return Ok(product);
        }

        [HttpGet("categories/{categories}")]
        public IActionResult GetProductsInCategories(string categories)
        {
            var categoriesArray = categories.Split(",");

            var productsInCategories = new List<Product>();

            foreach (var product in _dataAccess.Products)
            {
                for (int i = 0; i < categoriesArray.Length; i++)
                {
                    if (product.Categories.Contains(categoriesArray[i]))
                    {
                        productsInCategories.Add(product);
                    }
                }
            }

            return Ok(productsInCategories);
        }
    }
}
