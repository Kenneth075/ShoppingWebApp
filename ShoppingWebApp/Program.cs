using Microsoft.EntityFrameworkCore;
using ShoppingWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

//Add Services to the Container
builder.Services.AddControllersWithViews();  //Framework services to enable MVC.

builder.Services.AddScoped<IPiesRepository, PiesRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


builder.Services.AddDbContext<ShoppingWebAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});


var app = builder.Build();

app.UseStaticFiles();     //Middleware for all static files sure as HTML,CSS, JS.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    //This middleware throws any errors while at the development stage.
}

app.MapDefaultControllerRoute();   //Endpoint Middleware for routing.

app.Run();
