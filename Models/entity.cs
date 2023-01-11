using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebApplication3.Models
{
    public class entity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId ID { get; set; }
        public string Date { get; set; }
        public string Ip { get; set; }
    }
}
