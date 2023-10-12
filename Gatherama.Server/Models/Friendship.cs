﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Gatherama.Server.Models
{
    public class Friendship
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonElement("friend_request")]
        [JsonPropertyName("friend_request")]
        public int friend_request { get; set; }
        public int friend_accept { get; set; }

        public Person _idPerson { get; set; } = null!;
        public Person _idFriend { get; set; } = null!;
    }
}