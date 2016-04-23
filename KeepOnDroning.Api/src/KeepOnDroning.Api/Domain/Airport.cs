using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeepOnDroning.Api.Domain
{
    [Table("Airports")]
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Iata { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Altitude { get; set; }
        public decimal Timezone { get; set; }
        public string Dst { get; set; }
        public string Tz { get; set; }
    }
}
