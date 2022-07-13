using Geolocation.Core.Domain;
using Geolocation.Core.Repository;
using Geolocation.Infrastructure.EF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Infrastructure.EF
{
    public class SqlGeoLocationRepository : IGeoLocationRepository
    {
        private readonly GeoLocationDbContext _dbContext;

        public SqlGeoLocationRepository(GeoLocationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(GeolocationData location)
        {
            var model = new GeoLocationEntity
            {
                City = location.City,
                Id = location.Id,
                Ip = location.Ip,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Port = location.Port,
                Type = location.Type,
                Zip = location.Zip
            };

            await _dbContext.GeoLocations.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid locationId)
        {
            var entity = await _dbContext.GeoLocations.FirstOrDefaultAsync(x => x.Id == locationId);
            if (entity != null)
            {
                _dbContext.GeoLocations.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(Guid locationId)
        {
            var entity = await _dbContext.GeoLocations.FirstOrDefaultAsync(x => x.Id == locationId);
            return entity != null;
        }

        public Task<List<GeolocationData>> GetAllAsync()
        {
            var locations = _dbContext.GeoLocations.Select(x => new GeolocationData
            {
                City = x.City,
                Ip = x.Ip,
                Longitude = x.Longitude,
                Type = x.Type,
                Id = x.Id,
                Latitude = x.Latitude,
                Port = x.Port,
                Zip = x.Zip
            }).ToList();

            return Task.FromResult(locations);
        }
    }
}
