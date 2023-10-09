using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Gatherama.Server.Models
{
    public class Place
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("city")]
        [JsonPropertyName("city")]
        public string? city { get; set; } = null!;
        public string? country { get; set; } = null!;
        public double? lat { get; set; } = null!;
        public double? lng { get; set; } = null!;
    }
}
