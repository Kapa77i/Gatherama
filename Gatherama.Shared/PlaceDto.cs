using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared
{
    public class PlaceDto
    {
        public string? Id { get; set; }
        public string? city { get; set; } = null!;
        public string? country { get; set; } = null!;
        public double? lat { get; set; } = null!;
        public double? lng { get; set; } = null!;
    }
}
