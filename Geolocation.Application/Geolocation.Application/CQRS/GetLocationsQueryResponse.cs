using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Geolocation.Application.CQRS
{
    public class GetLocationsQueryResponse : IQueryResponse
    {
        public IEnumerable<GetLocationQueryItem> Items { get; set; }
    }
}
