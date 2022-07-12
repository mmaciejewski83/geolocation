using Geolocation.Application.CQRS;
using Geolocation.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Application.Handlers
{
    public class GetAllLocationsQueryHandler : IQueryHandler<GetLocationsQuery, GetLocationsQueryResponse>
    {
        private readonly IGeoLocationRepository _repository;

        public GetAllLocationsQueryHandler(IGeoLocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationsQueryResponse> QueryAsync(GetLocationsQuery query)
        {
            var list = await _repository.GetAllAsync();

            return new GetLocationsQueryResponse()
            {
                Items = list.Select(i => new GetLocationQueryItem
                {
                    City = i.City,
                    Id = i.Id,
                    Ip = i.Ip,
                    Latitude = i.Latitude,
                    Longitude = i.Longitude,
                    Port = i.Port,
                    Type = i.Type,
                    Zip = i.Zip
                })
            };
        }
    }
}
