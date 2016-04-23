using System;

namespace KeepOnDroning.Core.Domain
{
    public class ToDroneOrNotToDroneResponse
    {
        public bool HasNoFlyZone { get; set; }

        public bool HasDangerDanger { get; set; }

        public bool HasBirds { get; set; }

        public bool CrossingFlightpaths { get; set; }

        public int MaxHeight { get; set; }

        public WeatherResponse Weather { get; set; }
    }
}

