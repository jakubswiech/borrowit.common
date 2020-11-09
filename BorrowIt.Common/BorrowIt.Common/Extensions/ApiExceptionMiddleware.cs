using System;
using System.Threading.Tasks;
using BorrowIt.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace BorrowIt.Common.Extensions
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);                
            }
            catch (Exception ex)
            {
                string message;
                if (ex is BusinessLogicException)
                {
                    message = ex.Message;
                }
                else
                {
                    message = "unknown_error";
                }
                
                Log.Error(ex.ToString());
                
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = 400;
                httpContext.Response.ContentType = "application/json; charset=utf-8";
                httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                string json = JsonConvert.SerializeObject(new { message = message});
                await httpContext.Response.WriteAsync(json);
            }
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ApiExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiExceptionMiddleware>();
        }
    }
}