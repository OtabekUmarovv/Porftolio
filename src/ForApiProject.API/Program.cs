using ForApiProject.API.Extensions;
using ForApiProject.API.Middlewares;
using ForApiProject.Data.Contexts;
using ForApiProject.Data.IRepositories;
using ForApiProject.Data.Repositories;
using ForApiProject.Service.Interfaces;
using ForApiProject.Service.Mappers;
using ForApiProject.Service.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options
                .SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//DBContext
builder.Services.AddDbContext<MarketDBContext>(options => options
                .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Jwt
builder.Services.AddJwtServices(builder.Configuration);

//Custome Services
builder.Services.AddCustomeServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


