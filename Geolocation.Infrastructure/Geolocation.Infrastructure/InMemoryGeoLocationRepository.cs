using Geolocation.Core.Domain;
using Geolocation.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Infrastructure
{
    public class InMemoryGeoLocationRepository : IGeoLocationRepository
    {
        private List<GeolocationData> _data;

        public InMemoryGeoLocationRepository()
        {
            _data = new List<GeolocationData>();
        }

        public Task AddAsync(GeolocationData location)
        {
            _data.Add(location);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid locationId)
        {
            var item = _data.FirstOrDefault(x => x.Id == locationId);
            if (item != null)
            {
                _data.Remove(item);
            }
            return Task.CompletedTask;
        }

        public Task<List<GeolocationData>> GetAllAsync()
        {
            return Task.FromResult(_data);
        }
    }
}
