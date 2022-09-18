using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Payment.API.Extensions;
using Payment.Core;
using Payment.Infrastructure;
using Serilog;

// Add Serilog setup
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var isDevelopment = environment == Environments.Development;

IConfiguration config = ConfigurationSetup.GetConfig(isDevelopment);
LogSettings.SetUpSerilog(config);

try
{
    Log.Logger.Information("Application starting up");
    var builder = WebApplication.CreateBuilder(args);
    var configuration = builder.Configuration;

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddPaymentInfrastructure(config);
    builder.Services.AddApplicationLayer();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    Log.Logger.Fatal(e.StackTrace, "The application failed to start correctly"); 
}
finally
{
    Log.CloseAndFlush();
}
