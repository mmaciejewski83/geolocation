using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Geolocation.Infrastructure
{
    public class LoggingRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public LoggingRequestMiddleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger(typeof(LoggingRequestMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            var request = await FormatRequest(context.Request);
            _logger.LogInformation(request);
            await _next(context);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString}";
        }
    }
}
