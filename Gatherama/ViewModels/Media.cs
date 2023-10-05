using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared.Models
{
    public class Media
    {
        public uint MediaId { get; set; }
        public string Location { get; set; }
        public byte[] Image { get; set; }

        public uint FindingId {  get; set; }
        public uint SpeciesId { get; set; }
        public uint PersonId { get; set; }
        public uint PlaceId { get; set; }

        public virtual Finding Finding { get; set; } = null!;
        public virtual Species Species { get; set; } = null!;
        public virtual Person Person { get; set; } = null;
        public virtual Place Place { get; set; } = null!;
    }
}
