using System.Threading.Tasks;

namespace Geolocation.Core.Repository
{
    public interface IGeoLocationRepository
    {
        Task AddAsync(Domain.GeolocationData location);
        Task<Domain.GeolocationData> GetAllAsync();
    }
}
