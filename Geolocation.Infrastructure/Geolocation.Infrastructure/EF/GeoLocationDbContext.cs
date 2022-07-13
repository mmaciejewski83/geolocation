using Geolocation.Infrastructure.EF.Model;
using Microsoft.EntityFrameworkCore;

namespace Geolocation.Infrastructure.EF
{
    public class GeoLocationDbContext : DbContext
    {
        public DbSet<GeoLocationEntity> GeoLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Geo.db");
        }

    }
}
