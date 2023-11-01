using Microsoft.EntityFrameworkCore;
using Infra.Context;
using Application.ServiceCollection;
using Infra.ServiceCollection;
using System;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("tecgCHallengeDb");

builder.Services.AddDbContext<TechChallengeDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddApplicationServices();
builder.Services.AddRepositoryServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

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

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<TechChallengeDbContext>();
//    db.Database.Migrate();
//}

app.Run();
