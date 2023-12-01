using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared
{
    public class SpeciesDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public string? category { get; set; } = null!;
        public string? subCategory { get; set; } = null!;
        [Required(ErrorMessage = "Name of the species is required")]
        public string? s_name { get; set; } = null!;
        public string? latin_name { get; set; } = null!;
    }
}
