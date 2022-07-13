using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Infrastructure.EF.Model
{
    public class GeoLocationEntity
    {
        [Key]
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
