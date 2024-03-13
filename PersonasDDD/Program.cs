using Microsoft.EntityFrameworkCore;
using Personas.DDD.Domain.Repositories;
using Personas.DDD.Infracstructure;
using PersonasDDD.ApplicationsServices;
using PersonasDDD.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>(options =>
{
    //options.UseMySQL(builder.Configuration.GetConnectionString("cadenaMySql"));
    //options.UseNpgsql(builder.Configuration.GetConnectionString("cadenaPostgresSql"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSql"));

    //string tipoDeConexion = Environment.GetEnvironmentVariable("TIPO_DE_CONEXION");

    //if (tipoDeConexion == "MySQL")
    //{
    //    options.UseMySQL(builder.Configuration.GetConnectionString("cadenaMySql"));
    //}
    //else if (tipoDeConexion == "PostgreSQL")
    //{
    //    options.UseNpgsql(builder.Configuration.GetConnectionString("cadenaPostgresSql"));
    //}
    //else if (tipoDeConexion == "SQLServer")
    //{
    //    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSql"));
    //}


}
);

//registro de services
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<PersonaQueries>();
builder.Services.AddScoped<PersonaServices>();

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
