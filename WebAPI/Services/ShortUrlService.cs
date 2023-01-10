using WebAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace WebAPI.Services
{
    public class ShortUrlService
    {
        private readonly IMongoCollection<ShortenedUrl> _shortUrl;

        public ShortUrlService(IShortUrlStoreDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _shortUrl = database.GetCollection<ShortenedUrl>(settings.ShortUrlCollectionName);
        }

        public List<ShortenedUrl> Get() =>
            _shortUrl.Find(url => true).ToList();

        public ShortenedUrl Get(string id) =>
            _shortUrl.Find<ShortenedUrl>(url => url.Id == id).FirstOrDefault();

        public ShortenedUrl Create(ShortenedUrl url)
        {
            _shortUrl.InsertOne(url);
            return url;
        }

        public void Update(string id, ShortenedUrl urlIn) =>
            _shortUrl.ReplaceOne(url => url.Id == id, urlIn);

        public void Remove(ShortenedUrl urlIn) =>
            _shortUrl.DeleteOne(url => url.Id == urlIn.Id);

        public void Remove(string id) =>
            _shortUrl.DeleteOne(url => url.Id == id);
    }
}

