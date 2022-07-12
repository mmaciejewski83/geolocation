using System.Threading.Tasks;

namespace Geolocation.Application.CQRS
{
    public interface ICommandHandler<TCommand, TResponse> where TCommand : ICommand
        where TResponse : ICommandResponse
    {
        Task<TResponse> HandleAsync(TCommand command);
    }

    public interface ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }

}
