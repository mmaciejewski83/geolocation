using Geolocation.Application.CQRS;
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
            await _repository.DeleteAsync(command.LocationId);
        }
    }
}
