using LibraryManagerMvc.Data;
using LibraryManagerMvc.Data.Repositories;
using LibraryManagerMvc.Web.Extensions;
using LibraryManagerMvc.Web.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<WelcomeMiddleware>();

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("LibraryManagerMvcConnStr");
builder.Services.AddDbContext<LibraryManagerMvcContext>(options => options.UseSqlServer(connectionString));

/* Use any of the 3 service lifetimes to register your user-define services
 *     AddSingleton - Creates one instance of the service and uses it throughout the lifetime of the app, for all requests
 *     AddScoped - Creates a new instance of the service and uses it throughout a particular request/response cycle
 *     AddTransient - Creates a new instance each time the service is requested, whether within the same request or not.
 */

builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseWelcomeMiddleware();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Home}/{action=Index}/{id?}");

app.UseMiddleware<GoodbyeMiddleware>();

app.Run();
