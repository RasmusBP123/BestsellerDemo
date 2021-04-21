using BestsellerDemo.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BestsellerDemo
{
    public interface IDataAccess
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }

    public class FileReader : IDataAccess
    {
        private DataContainer Container { get; set; }
        private Category RootCategory { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public FileReader()
        {
            var json = File.ReadAllText("Data\\data.json");
            Container = JsonConvert.DeserializeObject<DataContainer>(json);
            
            Products = Container.Products;
            RootCategory = Container.RootCategory;
            Categories = RootCategory.Categories;
        }
    }
}
