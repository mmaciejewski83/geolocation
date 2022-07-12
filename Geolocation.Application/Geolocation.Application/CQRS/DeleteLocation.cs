using System;

namespace Geolocation.Application.CQRS
{
    public class DeleteLocation : ICommand
    {
        public Guid LocationId { get; set; }

        public DeleteLocation(Guid locationId)
            => LocationId = locationId;
    }
}
