using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Gatherama.Server.Models
{
    public class Friendship
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("friend_request")]
        [JsonPropertyName("friend_request")]
        public int friend_request { get; set; }
        public int friend_accept { get; set; }

        public virtual Person _idPerson { get; set; } = null!;
        public virtual Person _idFriend { get; set; } = null!;
    }
}
