using Gatherama.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Gatherama.Server.Services
{
    public class MediaService
    {
        private readonly IMongoCollection<Media> _mediaCollection;

        public MediaService(
            IOptions<GatheramaDatabaseSettings> gatheramaDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                gatheramaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                gatheramaDatabaseSettings.Value.DatabaseName);

            _mediaCollection = mongoDatabase.GetCollection<Media>(
                gatheramaDatabaseSettings.Value.MediaCollectionName);
        }

        public async Task<List<Media>> GetAsync() =>
            await _mediaCollection.Find(_ => true).ToListAsync();
    }
}
