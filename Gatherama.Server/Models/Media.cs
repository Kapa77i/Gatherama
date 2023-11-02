using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Gatherama.Server.Models
{
    public class Media
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("mediaLocation")]
        [JsonPropertyName("mediaLocation")]
        public string? mediaLocation { get; set; }
        public string? photo { get; set; }

        public virtual Finding _idFinding { get; set; } = null!;
    }
}
