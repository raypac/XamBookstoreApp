using Newtonsoft.Json;

namespace XamBookstoreApp.Mob.Models
{
    public class Book
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }
}
