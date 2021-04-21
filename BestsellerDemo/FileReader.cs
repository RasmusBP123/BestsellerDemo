using BestsellerDemo.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BestsellerDemo
{
    public interface IDataAccess
    {
        public Container Container { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Category RootCategory { get; set; }
    }

    public class FileReader : IDataAccess
    {
        public Container Container { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Category RootCategory { get; set; }

        public FileReader()
        {
            var json = File.ReadAllText("Data\\data.json");
            Container = JsonConvert.DeserializeObject<Container>(json);
            Products = Container.Products;
            RootCategory = Container.RootCategory;
            Categories = RootCategory.Categories;

        }
    }
}

            //var _options = new JsonDocumentOptions
            //{
            //    AllowTrailingCommas = true,
            //    CommentHandling = JsonCommentHandling.Skip
            //};

            //JsonDocument document = JsonDocument.Parse(json, _options);

            //var root = document.RootElement.EnumerateObject().FirstOrDefault();

            //var sgfs = new List<Product>();
            //foreach (var element in root.Value.EnumerateArray())
            //{
            //    products.Add(new Product
            //    {
            //        Id = element.GetProperty(nameof(Product.Id).ToLower()).GetInt32(),
            //        Brand = element.GetProperty(nameof(Product.Brand)).GetString(),
            //        Sizes = element.GetProperty(nameof(Product.Sizes)).EnumerateArray().Select(x => x.GetInt32()).ToArray(),
            //        Stock = element.GetProperty(nameof(Product.Stock)).GetInt32(),
            //        Color = element.GetProperty(nameof(Product.Color)).GetString(),
            //        Images = element.GetProperty(nameof(Product.Images)).EnumerateArray().Select(x => new Image { Url = new Uri(x.GetString()) }).ToList(),
            //        Prize = element.GetProperty(nameof(Product.Prize)).GetDouble(),
            //        //Name = element.GetProperty(nameof(Product.Name)).EnumerateObject().Select(x => x.Value),
            //    });
            //}