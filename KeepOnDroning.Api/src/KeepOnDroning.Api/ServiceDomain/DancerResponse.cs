namespace KeepOnDroning.Api.ServiceDomain
{
    public class DancerResponse
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
        public bool HasNoFlyZone { get; set; }
        public bool HasDangerDanger { get; set; }
        public bool HasBirds { get; set; }
        public bool CrossingFlightpaths { get; set; }
        public int MaxHeight { get; set; }
        public WeatherResponse Weather { get; set; }
    }
}