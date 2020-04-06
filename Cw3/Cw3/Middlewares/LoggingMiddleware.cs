using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //CUSTOM CODE

            //Save to a log-file (named request-log.txt):
            //1: HTTP method (GET, POST etc.)
            string method = httpContext.Request.Method;
            //2: Routing path (like "/api/students")
            //httpContext.Request.Path
            string routePath = httpContext.Request.Path;

            //3: Request Body (e.g. sent JSON)

            var bodyStream = string.Empty;
            using (var reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true)) {
                bodyStream = await reader.ReadToEndAsync();
                //writing BodyStream to the log file
            }
            //4: Query string content (e.g. ?name=Kowalski)
            //httpContext.Request.QueryString
            string queryString = httpContext.Request.QueryString.ToString();

                await _next(httpContext);
        }
    }
}
