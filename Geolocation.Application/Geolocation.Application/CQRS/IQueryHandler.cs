using System.Threading.Tasks;

namespace Geolocation.Application.CQRS
{
    public interface IQueryHandler<TQuery, TResponse> where TQuery : class, IQuery
        where TResponse : class, IQueryResponse
    {
        Task<TResponse> QueryAsync(TQuery query);
    }
}
