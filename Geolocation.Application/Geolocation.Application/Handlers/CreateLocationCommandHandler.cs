using Geolocation.Application.CQRS;
using Geolocation.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Application.Handlers
{
    public class CreateLocationCommandHandler : ICommandHandler<CreateLocation>
    {
        private readonly IGeoLocationRepository _repository;

        public CreateLocationCommandHandler(IGeoLocationRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(CreateLocation command)
        {
            var geoLocation = new Geolocation.Core.Domain.GeolocationData()
            {
                City = command.City,
                Id = command.Id,
                Ip = command.Ip,
                Latitude = command.Latitude,
                Longitude = command.Longitude,
                Port = command.Port,
                Type = command.Type,
                Zip = command.Zip
            };
            await _repository.AddAsync(geoLocation);
        }
    }
}
