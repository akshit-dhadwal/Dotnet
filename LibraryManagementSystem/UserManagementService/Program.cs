using AutoMapper;
using DataLayer.ContextFiles;
using DataLayer.DBOperations.Repositories;
using DataLayer.InterfaceRepositories;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using ServiceLayer.Utils;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


// Add repositories to container.

builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();



// For Entity Framework
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// For AutoMapper
builder.Services.AddSingleton(provider => new MapperConfiguration(config =>
{
    config.AddProfile(new MappingProfile());
}).CreateMapper());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
