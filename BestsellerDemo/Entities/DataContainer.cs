using Newtonsoft.Json;
using System.Collections.Generic;

namespace BestsellerDemo.Entities
{
    public class DataContainer
    {
        public IEnumerable<Product> Products { get; set; }
        [JsonProperty("categories")]
        public Category RootCategory { get; set; }
    }
}
