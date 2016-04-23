using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KeepOnDroning.Api.Domain.Enums;

namespace KeepOnDroning.Api.Domain
{
    [Table("Oois")]
    public class Ooi
    {
        [Key]
        public long Id { get; set; }
        public string UniqueIdentifier { get; set; }
        public string Name { get; set; }
        public double CurrentLat { get; set; }
        public double CurrentLng { get; set; }
        public double DestinationLat { get; set; }
        public double DestinationLng { get; set; }
        public double Speed { get; set; }
        public EOoiType Type { get; set; }
    }
}
