using ClothesStore.API.Middlewares;
using ClothesStore.Infrastructure;
using ClothesStrore.Application;
using ClothesStrore.Application.Behaviors;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add logger
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});

builder.Services.ConfigurationApplication(builder.Configuration);
builder.Services.ConfigurationInfrastructure(builder.Configuration);

//builder.Services.AddLogging();
//Configure Global Handeling
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//builder.Services.AddControllers().AddNewtonsoftJson();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
