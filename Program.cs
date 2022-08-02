using AplicationCore.Helpers;
using Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(
        option =>
        {
            option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            option.UseMemberCasing();
        }
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration["MyConnection"];
builder.Services.AddDbContext<DataBaseContext>(
    opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

ServicesHelper.RegisterBusinesses(services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
