using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpoints.Security;
using CourseManagement;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Properties;
using CourseManagement.IntegrationEvents.Handlers;
using CourseManagement.IntegrationEvents.Events;
using Services.Common;
using CourseManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
{
    services.AddCors();

    // FastEndpoints
    services.AddFastEndpoints();
    services.AddJWTBearerAuth(builder.Configuration["JwtSecret"]);
    services.AddSwaggerDoc();

    // Configuration
    services.Configure<IPConfig>(builder.Configuration.GetSection("IP"));

    // Database
    string connectionString = builder.Configuration.GetSection("Database")["ConnectionString"];
    services.AddDbContext<CourseDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

    // Event Bus
    ConfigureServices.AddEventBus(builder);

    builder.Services.AddTransient<IFileService, GoogleDriveFileService>();
    builder.Services.AddTransient<UserEmailChangedIntegrationEventHandler>();
    builder.Services.AddTransient<UserNameChangedIntegrationEventHandler>();
}
var app = builder.Build();
{
    app.UseHttpsRedirection();

    app.UseCors();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseFastEndpoints();

    app.UseSwaggerGen();

    var eventBus = app.Services.GetRequiredService<Infrastructure.EventBus.Generic.IEventBus>();
    eventBus.Subscribe<UserEmailChangedIntegrationEvent, UserEmailChangedIntegrationEventHandler>();
    eventBus.Subscribe<UserNameChangedIntegrationEvent, UserNameChangedIntegrationEventHandler>();
}
app.Run();
