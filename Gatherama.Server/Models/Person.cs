using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Gatherama.Server.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("firstName")]
        [JsonPropertyName("firstName")]
        public string? firstName { get; set; } = null!;
        public string? lastName { get; set; } = null!;
        public string? username { get; set; } = null!;
        public string? email { get; set; } = null!;
        public string? password { get; set; }
    }
}
