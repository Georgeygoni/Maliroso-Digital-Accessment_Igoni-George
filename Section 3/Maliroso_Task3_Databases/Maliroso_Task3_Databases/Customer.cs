using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Maliroso_Task3_Databases
{
    public class Customer
    {
        [BsonId]
        public ObjectId CustomerId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}
