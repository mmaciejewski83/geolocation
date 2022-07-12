using System;

namespace Geolocation.Application.CQRS
{
    public class CreateLocation : ICommand
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Ip { get; set; }
        public int Port { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
