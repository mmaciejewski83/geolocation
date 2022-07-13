using System;
using System.ComponentModel.DataAnnotations;

namespace Geolocation.Application.CQRS
{
    public class CreateLocation : ICommand
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        
        [Required]
        public string Ip { get; set; }

        [Required]
        public int Port { get; set; }

        [Required] 
        public string Type { get; set; }

        [Required]
        public string City { get; set; }
        
        [Required]
        public string Zip { get; set; }

        [Required] 
        public float Latitude { get; set; }

        [Required] 
        public float Longitude { get; set; }
    }
}
