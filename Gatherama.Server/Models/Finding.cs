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
     
        public int? _private { get; set; }
        public DateTime? datetime { get; set; } = null!;
        public string? amount { get; set; } = null!;

           [BsonElement("memo")]
        [JsonPropertyName("memo")]
        public string? memo { get; set; } = null!;


        public virtual Species _idSpecies { get; set; } = null!;
        public virtual Person _idPerson { get; set; } = null!;
        public virtual Place _idPlace { get; set; } = null!;
    }
}
