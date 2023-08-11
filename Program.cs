using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simpleproject.models;
using simpleproject.repository;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddTransient(typeof(irepository<>), typeof(Repository<>));

builder.Services.Configure<MvcOptions>(opt => { opt.ReturnHttpNotAcceptable = true; opt.RespectBrowserAcceptHeader = true; });

builder.Services.AddTransient(typeof(irepositoryid<>), typeof(repositoryid<>));

builder.Services.AddDbContext<datacontext>(opts => {

    opts.UseSqlServer(builder.Configuration["ConnectionStrings:productConnection"]);
    opts.EnableSensitiveDataLogging(true);

});

var app = builder.Build();

app.MapControllers();

app.UseMiddleware<simpleproject.test>();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<datacontext>();

seeddata.seedatabase(context);

const string baseurl = "ap/products";
// we use double curly brackets to escape single curly brackets
app.MapGet($"{baseurl}/{{id}}", async(HttpContext context, datacontext data) =>
{
    string? id = context.Request.RouteValues["id"] as string;

    if(id != null) 
    {
        product? p = data.products.Find(long.Parse(id));

        if (p == null) 
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
        else
        {
            context.Response.ContentType= "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(p));
        }
    }
});


app.MapGet(baseurl, async (HttpContext context, datacontext data) => {

    context.Response.ContentType= "application/json";

    await context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<product>>(data.products));

});


app.MapPost(baseurl, async (HttpContext context, datacontext data) => { 

    product? p = await JsonSerializer.DeserializeAsync<product>(context.Request.Body);

    if (p != null) {
    
    
        await data.products.AddAsync(p);

        await data.SaveChangesAsync();

        context.Response.StatusCode = StatusCodes.Status200OK;
    }


});

app.MapGet("/", () => "Hello World!");

app.Run();
