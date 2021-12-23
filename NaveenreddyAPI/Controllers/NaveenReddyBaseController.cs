using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;

namespace NaveenreddyAPI.Controllers
{
    public class NaveenReddyBaseController<T> : ControllerBase where T : NaveenReddyBaseController<T>
    {
        private ITokenManager TokenManager;
        private ILogger<T> Logger;
        private IMemoryCache Cache;
        protected ILogger<T> _logger => _logger ?? (Logger = HttpContext?.RequestServices.GetService<ILogger<T>>());
        protected ITokenManager _tokenManager => _tokenManager ?? (TokenManager = HttpContext?.RequestServices.GetService<ITokenManager>());
        protected IMemoryCache _cache => _cache ?? (Cache = HttpContext?.RequestServices.GetService<IMemoryCache>());
    }
}
