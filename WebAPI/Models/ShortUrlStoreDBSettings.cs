namespace WebAPI.Models
{
    public class ShortUrlStoreDBSettings : IShortUrlStoreDBSettings
    {
        public string ShortUrlCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IShortUrlStoreDBSettings
    {
        string ShortUrlCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
