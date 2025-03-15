using System.Text.Json.Serialization;
using CRUD.DAL.Context;
using CRUD.DAL.Entities.Abstraction;
using CRUD.Service.ReflectionApplication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add database
builder.Services.AddDbContext<MyDbContext>(optionsBuilder =>
{
    IConfiguration config = builder.Configuration;
    optionsBuilder.UseNpgsql(config.GetConnectionString("DataBase"));
});

var repositoryService = ServiceLocator.FindAllRepositories<BaseEntity>();

foreach (var listOfClasses in repositoryService.SelectMany(repo => repo.Value))
{
    builder.Services.AddTransient(listOfClasses);
}

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json","CRUD API v1");
    options.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
