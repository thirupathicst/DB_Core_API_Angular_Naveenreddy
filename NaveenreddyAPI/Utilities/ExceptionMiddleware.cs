using DBRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NaveenreddyAPI.Utilities
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IMemoryCache _cache;
        private readonly ITokenManager _tokenManager;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IMemoryCache cache, ITokenManager tokenManager)
        {
            _logger = logger;
            _cache = cache;
            _tokenManager = tokenManager;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
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

            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            if (ex is MyCustomException||ex is NoDetailsFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    statuscode = context.Response.StatusCode,
                    message = ex.Message
                }.ToString());
            }
            else if (ex is UnauthorizedAccessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    statuscode = context.Response.StatusCode,
                    message = ex.Message
                }.ToString());
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    statuscode = context.Response.StatusCode,
                    message = ex.Message
                }.ToString());
            }
        }

    }
}