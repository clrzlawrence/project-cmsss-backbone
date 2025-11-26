using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectCms.Models;

namespace ProjectCms.Services
{
    public class ArchivedPageService
    {
        private readonly IMongoCollection<ArchivedPage> _collection;

        public ArchivedPageService(IOptions<MongoDbSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var db = client.GetDatabase(mongoSettings.Value.DatabaseName);

            // simple: direct collection name
            _collection = db.GetCollection<ArchivedPage>("ArchivedPages");
        }

        public async Task CreateAsync(ArchivedPage archivedPage) =>
            await _collection.InsertOneAsync(archivedPage);

        public async Task<List<ArchivedPage>> GetAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<List<ArchivedPage>> GetByTypeAsync(string archiveType) =>
            await _collection.Find(x => x.ArchiveType == archiveType).ToListAsync();
    }
}
