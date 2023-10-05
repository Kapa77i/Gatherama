using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared.Models
{
    public class Person
    {
        public uint PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public uint FriendShipId { get; set; }
        public uint FriendId { get; set; }
        public virtual Friendship Friendship { get; set; } = null!;
        public virtual ICollection<Friendship> Friendships { get; } = new List<Friendship>();
    }
}
