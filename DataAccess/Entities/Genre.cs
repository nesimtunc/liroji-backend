using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Entities
{
    public class Genre : BaseEntity
    {
        public Genre()
        {

        }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}