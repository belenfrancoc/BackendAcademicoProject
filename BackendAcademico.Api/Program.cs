using BackendAcademico.Core.Interfaces;
using BackendAcademico.Infrastructure.Data;
using BackendAcademico.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cadenaConexion = builder.Configuration.GetConnectionString("defaultConnection");

builder.Services.AddScoped<IDbConnection>(provider => new OracleConnection(cadenaConexion));

builder.Services.AddDbContext<ModelContext>(x =>
    x.UseOracle(
        cadenaConexion,
        options => options.UseOracleSQLCompatibility("23")
    )
);

builder.Services.AddTransient<IInscripcionRepository, InscripcionRepository>();
builder.Services.AddTransient<IEstudianteRepository, EstudianteRepository>();

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
