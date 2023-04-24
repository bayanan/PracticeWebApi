using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiPractice.BusinessLogic.Limits;

namespace WebApiPractice.Middleware
{
    public class RequestLimiterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RequestLimiter _limiter;

        public RequestLimiterMiddleware(RequestDelegate next, RequestLimiter limiter)
        {
            _next = next;
            _limiter = limiter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!_limiter.TryAcquireRequest())
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                return;
            }

            try
            {
                await _next(context);
            }
            finally
            {
                _limiter.ReleaseRequest();
            }
        }
    }
}
