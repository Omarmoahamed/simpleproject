
using simpleproject.models;

namespace simpleproject
{
    public class test
    {
        private RequestDelegate next;

        public test(RequestDelegate next) {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, datacontext datacontext)
        {
            if(context.Request.Path == "/test") 
            {
                await context.Response.WriteAsync($"there are {datacontext.products.Count()}\n");
                await context.Response.WriteAsync($"there are {datacontext.categories.Count()}");
            }

            else { await next(context); }
        }
    }
}
