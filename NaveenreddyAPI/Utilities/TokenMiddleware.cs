using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace NaveenreddyAPI.Utilities
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IMemoryCache _cache;
        private readonly ITokenManager _tokenManager;

        public TokenMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IMemoryCache cache, ITokenManager tokenManager)
        {
            _logger = logger;
            _cache = cache;
            _tokenManager = tokenManager;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                if ((_cache.Get($"PersonId-{_tokenManager.GetUserId()}") == null))
                {
                    throw new UnauthorizedAccessException("Token expired or invalid");
                }
            }
            await _next(httpContext);
        }
    }
}
