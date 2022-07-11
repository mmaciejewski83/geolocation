namespace Geolocation.Core.Domain
{
    public class GeolocationData
    {
        public string Ip { get; set; }
        public int Port { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
