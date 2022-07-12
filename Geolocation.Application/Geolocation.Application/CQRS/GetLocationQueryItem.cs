using System;

namespace Geolocation.Application.CQRS
{
    public class GetLocationQueryItem
    {
        public Guid Id { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
