var builder = WebApplication.CreateBuilder(args);

//Add Services to the Container
builder.Services.AddControllersWithViews();  //Framework services to enable MVC.


var app = builder.Build();

app.UseStaticFiles();     //Middleware for all static files sure as HTML,CSS, JS.

app.MapGet("/", () => "Hello World!");

app.Run();
