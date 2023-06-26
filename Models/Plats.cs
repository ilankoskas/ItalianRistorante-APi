using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace WebApplicationAPi.Models
{
    public class Plats
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }

        public string? Name { get; set; }
        public int Price { get; set; }


    }
}
