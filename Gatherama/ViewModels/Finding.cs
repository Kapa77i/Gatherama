using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared.Models
{
    public class Finding
    {
        public uint FindingId { get; set; }
        public uint SpeciesId { get; set; }
        public uint PersonId { get; set; }
        public uint PlaceID { get; set; }
        public sbyte? Private { get; set; }
        public DateTime DateTime { get; set; }
        public string Amount { get; set; }
        public string Memo { get; set; }

        public virtual Species Species { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
        public virtual Place Place { get; set; } = null!;
        public virtual ICollection<Media> Media { get; } = new List<Media>();
    }
}
