using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Gatherama.Server.Models
{
    public class Finding
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("memo")]
        [JsonPropertyName("memo")]
        public int? Private { get; set; }
        public DateTime? datetime { get; set; } = null!;
        public string? amount { get; set; } = null!;
        public string? memo { get; set; } = null!;

        public virtual Species Species { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
        public virtual Place Place { get; set; } = null!;
    }
}
