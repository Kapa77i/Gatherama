using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Gatherama.Server.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("firstName")]
        [JsonPropertyName("firstName")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name cannot have less than 3 characters and more than 20 characters in length")]
        public string? firstName { get; set; } = null!;
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name cannot have less than 3 characters and more than 20 characters in length")]
        public string? lastName { get; set; } = null!;
        public string? username { get; set; } = null!;
        public string? email { get; set; } = null!;
        public string? password { get; set; }
    }
}
