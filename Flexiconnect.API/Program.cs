using Flexiconnect.Application.Mappings;
using Flexiconnect.Application.Services.Implementations;
using Flexiconnect.Application.Services.Interfaces;
using Flexiconnect.Domain.Entities;
using Flexiconnect.Domain.Implementation;
using Flexiconnect.Domain.Interfaces;
using Flexiconnect.Infrastructure.Persistence;
using Flexiconnect.Infrastructure.Persistence.Interfaces;
using Flexiconnect.Infrastructure.Persistence.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;


var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("NextgenConn");
builder.Services.AddSingleton<ApplicationDbContext>();
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connString));
builder.Services.AddScoped<IActionMenuMasterService, ActionMenuMasterService>();
builder.Services.AddScoped<IActionMenuMasterDomain, ActionMenuMasterDomain>();
builder.Services.AddScoped<IGenericRepository<ActionMenuMaster>, GenericRepository<ActionMenuMaster>>();
// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
