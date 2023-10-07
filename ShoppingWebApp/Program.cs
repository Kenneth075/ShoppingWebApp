using Microsoft.EntityFrameworkCore;
using ShoppingWebApp.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//Add Services to the Container
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});  

builder.Services.AddRazorPages();

builder.Services.AddScoped<IPiesRepository, PiesRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository,  OrderRepository>();


builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(sp=>ShoppingCartRepository.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


builder.Services.AddDbContext<ShoppingWebAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ShoppingWebAppDbContext>();;


var app = builder.Build();

app.UseStaticFiles();     //Middleware for all static files sure as HTML,CSS, JS.
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    //This middleware throws any errors while at the development stage.
}

app.MapDefaultControllerRoute();   //Endpoint Middleware for routing.

app.MapRazorPages();

Seeder.Seed(app);

app.Run();
