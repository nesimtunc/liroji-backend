using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
            this.IsDeleted = false;
        }

        /// <summary>
        /// Entity's unique identifier
        /// </summary>
        /// <value>The identifier.</value>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("created_by")]
        public String CreatedBy { get; set; }

        [BsonElement("is_deleted")]
        public bool IsDeleted { get; set; }

    }
}
