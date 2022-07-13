using Geolocation.Application.CQRS;
using Geolocation.Application.Exceptions;
using Geolocation.Core.Repository;
using System.Threading.Tasks;

namespace Geolocation.Application.Handlers
{
    public class DeleteLocationCommandHandler : ICommandHandler<DeleteLocation>
    {
        private readonly IGeoLocationRepository _repository;

        public DeleteLocationCommandHandler(IGeoLocationRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(DeleteLocation command)
        {
            var exists = await _repository.ExistsAsync(command.LocationId);
            if (!exists)
            {
                throw new GeoLocationNotFoundException(command.LocationId);
            }

            await _repository.DeleteAsync(command.LocationId);
        }
    }
}
