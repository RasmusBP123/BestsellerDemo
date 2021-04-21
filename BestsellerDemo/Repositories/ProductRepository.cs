using BestsellerDemo.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BestsellerDemo.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        Product GetById(int id);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _dataAccess;

        public ProductRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _dataAccess.Products;
            return products;
        }

        public Product GetById(int id)
        {
            var product = _dataAccess.Products.FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
