using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared
{
    public class FindingDto
    {
        
        public string Id { get; set; } = null!;
        [Required(ErrorMessage = "Private is required")]
        public int? _private { get; set; }
        [Required(ErrorMessage = "Date is required")]
        public DateTime? datetime { get; set; } = null!;
        [Required(ErrorMessage = "Amount is required")]
        public string? amount { get; set; } = null!;
        public string? memo { get; set; } = null!;
        //public uint? _idSpecies { get; set; }
        //public uint? _idPerson { get; set; }
        //public uint _idPlace { get; set; }
        [Required(ErrorMessage = "Species is required")]
        public virtual SpeciesDto _idSpecies { get; set; } = null!;
        [Required]
        public virtual PersonDto _idPerson { get; set; } = null!;
        [Required]
        public virtual PlaceDto _idPlace { get; set; } = null!;
    }
}
