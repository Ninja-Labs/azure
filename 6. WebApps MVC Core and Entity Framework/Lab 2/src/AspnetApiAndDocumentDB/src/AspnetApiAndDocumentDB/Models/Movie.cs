using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace AspnetApiAndDocumentDB.Models
{
    public class Movie //: Document
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }
    }
}
