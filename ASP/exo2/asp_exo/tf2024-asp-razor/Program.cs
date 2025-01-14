using Microsoft.EntityFrameworkCore;
using tf2024_asp_razor.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var configuration = builder.Configuration;

builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Aeroport")));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();