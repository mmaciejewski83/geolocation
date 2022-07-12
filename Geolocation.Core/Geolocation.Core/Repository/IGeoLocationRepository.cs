using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geolocation.Core.Repository
{
    public interface IGeoLocationRepository
    {
        Task AddAsync(Domain.GeolocationData location);
        Task<List<Domain.GeolocationData>> GetAllAsync();
        Task DeleteAsync(Guid locationId);
    }
}
