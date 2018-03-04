using System;
using System.Threading.Tasks;
using FormBuilder.API.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FormBuilder.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this._next.Invoke(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var response = new APIResponse();
                response.Messages.Add(ex.Message);
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    response.Messages.Add(innerException.Message);
                    innerException = innerException.InnerException;
                }
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}