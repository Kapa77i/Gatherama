using Gatherama.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Gatherama.Server.Services
{
    public class FriendshipService
    {
        private readonly IMongoCollection<Friendship> _friendshipCollection;

        public FriendshipService(IOptions<GatheramaDatabaseSettings> gatheramaDatabaseSettings)

        {
            var mongoClient = new MongoClient(
                gatheramaDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
            gatheramaDatabaseSettings.Value.DatabaseName);

            _friendshipCollection = mongoDatabase.GetCollection<Friendship>(
            gatheramaDatabaseSettings.Value.FriendshipCollectionName);
        }

        public async Task<List<Friendship>> GetAsync() =>
            await _friendshipCollection.Find(_ => true).ToListAsync();
    }
}
