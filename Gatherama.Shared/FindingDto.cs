using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared
{
    public class FindingDto
    {
        public string Id { get; set; }
        public int? _private { get; set; }
        public DateTime? datetime { get; set; } = null!;
        public string? amount { get; set; } = null!;
        public string? memo { get; set; } = null!;
        //public uint? _idSpecies { get; set; }
        //public uint? _idPerson { get; set; }
        //public uint _idPlace { get; set; }
        public virtual SpeciesDto _idSpecies { get; set; } = null!;
        public virtual PersonDto _idPerson { get; set; } = null!;
        public virtual PlaceDto _idPlace { get; set; } = null!;
    }
}
