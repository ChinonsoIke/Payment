using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Payment.API.Extensions;
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
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddValidatorsFromAssemblyContaining<Program>();

    builder.Services.AddDbContext<PaymentDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

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
}
catch (Exception e)
{
    Log.Logger.Fatal(e.StackTrace, "The application failed to start correctly");
}
finally
{
    Log.CloseAndFlush();
}
