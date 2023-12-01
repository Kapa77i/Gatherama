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
        [Required(ErrorMessage = "City is required")]
        public string? city { get; set; } = null!;
        [Required(ErrorMessage = "Country is required")]
        public string? country { get; set; } = null!;
        [Required(ErrorMessage = "Latitude is required")]
        public double? lat { get; set; } = null!; 
        [Required(ErrorMessage = "Longitude is required")]
        public double? lng { get; set; } = null!;
    }
}
