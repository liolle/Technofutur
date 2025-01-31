using apiExo.dal.database;
using apiExo.bll.services;
using apiExo.bll.entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddControllers();


builder.Services.AddScoped<IDataContext,DataContext>();
builder.Services.AddTransient<ITaskService,TaskService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

RouteConfig.RegisterRoutes(app);

app.Run();