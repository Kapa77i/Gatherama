namespace Gatherama.Server.Models
{
    public class GatheramaDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PersonCollectionName { get; set; } = null!;

        public string MediaCollectionName { get; set; } = null!;
        public string FriendshipCollectionName { get; set; } = null!;
    }
}
