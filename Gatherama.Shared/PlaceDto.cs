using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared
{
    public class PlaceDto
    {
        public string? Id { get; set; }
        [Required]
        public string? city { get; set; } = null!;
        [Required]
        public string? country { get; set; } = null!;
        [Required]
        public double? lat { get; set; } = null!; 
        [Required]
        public double? lng { get; set; } = null!;
    }
}
