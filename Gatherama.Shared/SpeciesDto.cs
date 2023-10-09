using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared
{
    public class SpeciesDto
    {
        public string? Id { get; set; }
        public string? category { get; set; } = null!;
        public string? subCategory { get; set; } = null!;
        public string? s_name { get; set; } = null!;
        public string? latin_name { get; set; } = null!;
    }
}
