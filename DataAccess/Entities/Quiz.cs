using System;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccess.Entities
{
    public class Quiz : BaseEntity
    {
        public Quiz()
        {

        }

        [BsonElement("emoji")]
        public string Emoji { get; set; }

        [BsonElement("meaning")]
        public string Meaning { get; set; }

        [BsonElement("song_id")]
        public string SongId { get; set; }

    }
}
