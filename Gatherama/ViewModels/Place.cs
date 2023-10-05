using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gatherama.Shared.Models
{
    public class Place
    {
        public uint PlaceId {  get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Lat { get; set; }
        public string? Long {  get; set; }
    }
}
