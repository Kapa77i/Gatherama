using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Gatherama.Server.Models
{
    public class Species
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
      
        public string? category { get; set; } = null!;
        public string? subCategory { get; set; } = null!;

        [BsonElement("s_name")]
        [JsonPropertyName("s_name")]
        public string? s_name { get; set; } = null!;
        public string? latin_name { get; set; } = null!;

    }
}
