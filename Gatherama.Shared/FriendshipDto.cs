using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared
{
    public class FriendshipDto
    {
        public string? Id { get; set; }
        public int friend_request { get; set; }
        public int friend_accept { get; set; }

        public virtual PersonDto _idPerson { get; set; } = null!;
        public virtual PersonDto _idFriend { get; set; } = null!;
    }
}
