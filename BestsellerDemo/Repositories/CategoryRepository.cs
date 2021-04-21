using BestsellerDemo.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BestsellerDemo.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        int GetStockForCategory(string categoryId);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDataAccess _dataAccess;

        public CategoryRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Category> GetAll()
        {
            return _dataAccess.Categories;
        }

        public int GetStockForCategory(string categoryId)
        {
            var products = _dataAccess.Products;
            var stockCount = 0;

            foreach (var product in products)
            {
                var isInCategory = product.Categories.Any(x => x == categoryId);
                if (isInCategory)
                {
                    var isValidNumber = int.TryParse(product.Stock, out var result);
                    if (isValidNumber)
                    {
                        stockCount += result;
                    }
                }
            }

            return stockCount;
        }
    }

}
