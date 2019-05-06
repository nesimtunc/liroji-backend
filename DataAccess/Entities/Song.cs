using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Entities
{
    public class Song : BaseEntity
    {
        public Song()
        {

        }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("artist_id")]
        public string ArtistId { get; set; }

        [BsonElement("genre_id")]
        public string GenreId { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("language")]
        public string Langugage { get; set; }
    }
}