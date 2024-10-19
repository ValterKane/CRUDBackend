using System.Diagnostics;
using System.Text.Json.Serialization;
using CRUD.BLL.Controllers;
using CRUD.DAL.Context;
using CRUD.DAL.Entities;
using CRUD.DAL.Entities.Abstraction;
using CRUD.DAL.Repository;
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
