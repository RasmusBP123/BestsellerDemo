using Newtonsoft.Json;
using System.Collections.Generic;

namespace BestsellerDemo.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public string Brand { get; set; }
        public double Prize { get; set; }
        public string Color { get; set; }
        public string Stock { get; set; }
        [JsonProperty("size")]
        public string[] Sizes { get; set; }
        public IEnumerable<string> Images { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}
