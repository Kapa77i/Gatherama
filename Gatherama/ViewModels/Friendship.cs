using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared.Models
{
    public class Friendship
    {
        public uint FriendshipId { get; set; }
        public uint FriendId { get; set; }
        public int FriendRequest {  get; set; }
        public int FriendAccept { get; set; }
        public uint PersonId { get; set; }

        public virtual Person Person { get; set; } = null!;
    }
}
