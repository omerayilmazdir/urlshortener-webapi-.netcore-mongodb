using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace WebAPI.Models
{
    public class ShortenedUrl
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

       
        public string OriginalUrl { get; set; }
        public string ShortCode { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
