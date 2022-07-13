using System;

namespace Geolocation.Application.Exceptions
{
    public class GeoLocationNotFoundException : CoreException
    {
        public override string Code { get; } = "location_not_found";
        public Guid Id { get; }

        public GeoLocationNotFoundException(Guid id) : base($"location with id: {id} was not found.")
            => Id = id;
    }
}
