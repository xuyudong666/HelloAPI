using Microsoft.AspNetCore.Mvc.Filters;

namespace HelloAPI
{
    public class HtpMethodCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public HtpMethodCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {

            var requestMethod =new HttpMethod(context.Request.Method.ToUpper());  

            if(requestMethod == HttpMethod.Get || requestMethod == HttpMethod.Head)
            {
                await _next(context);  
            }
            else {
                context.Response.StatusCode = 400;
                context.Response.Headers.Add("X-AllowHTTPVerb", new[] { "GET,HEAD" });
                await context.Response.WriteAsync("只支持GET、HEAD方法");
            }
        }
    }
}
