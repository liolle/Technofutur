using AspcoreBll;
using AspcoreBll.Auth;
using AspInterfaces;
using Microsoft.EntityFrameworkCore;
using tf2024_asp_razor.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var configuration = builder.Configuration;

builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<IDataContext,DataContext>( s=> {
    DbContextOptions<DataContext> options = 
    new DbContextOptionsBuilder<DataContext>().UseSqlServer(configuration.GetConnectionString("Aeroport")).Options;
    return new DataContext(options);
}
);

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddCookiePolicy(policy=>{
    policy.ConsentCookie.Name = "Airline-Consent";
    policy.ConsentCookie.HttpOnly = true;
    policy.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddScoped<SessionManager>();
builder.Services.AddSession(options=>{
    options.Cookie.Name = "ASPDotNetAirline.session";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddScoped<IAuthService,AuthService>();

builder.Services.AddTransient<IPlaneService, PlaneService>();
builder.Services.AddTransient<ITaxableService, TaxableService>();
builder.Services.AddTransient<IPlaneTypeService, PlaneTypeService>();
builder.Services.AddTransient<IMecanicService, MecanicService>();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.UseAuthorization();
app.UseSession();

RouteConfig.RegisterRoutes(app);

app.Run();