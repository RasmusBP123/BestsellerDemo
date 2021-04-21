using Newtonsoft.Json;
using System.Collections.Generic;

namespace BestsellerDemo.Entities
{
    public class Category
    {
        public string Id { get; set; }
        [JsonProperty("parent_category_id")]
        public string ParentCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public int Level { get; set; }
        public Name Name { get; set; }
    }
}
