using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Properties;
using CourseManagement.IntegrationEvents.Handlers;
using CourseManagement.IntegrationEvents.Events;
using Services.Common;
using CourseManagement.Data;
using CourseManagement.Services;
using System.Text.Json.Serialization;
using CourseManagement.Data.Repositories;
using CourseManagement.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
{
    services.AddCors((options) =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("https://localhost", "http://localhost", "http://localhost:3000", "https://nadegamraolpfrontend.azurewebsites.net")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
    });

    // FastEndpoints
    services.AddFastEndpoints();
    services.AddJWTBearerAuth(builder.Configuration["JWT:Secret"]);
    services.SwaggerDocument();

    // Configuration
    services.Configure<IPConfig>(builder.Configuration.GetSection("IP"));

    // Database
    string connectionString = builder.Configuration.GetSection("Database")["ConnectionString"];
    services.AddDbContext<CourseDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

    // Event Bus
    ConfigureServices.AddEventBus(builder);

    // Services
    builder.Services.AddTransient<IFileService, GoogleDriveFileService>();

    // Repositories
    builder.Services.AddScoped<IRepository<CourseLanguage>, CourseLanguageRepository>();
    builder.Services.AddScoped<IRepository<Course>, CourseRepository>();
    builder.Services.AddScoped<IRepository<CourseRequirement>, CourseRequirementRepository>();
    builder.Services.AddScoped<IRepository<CourseSubtitle>, CourseSubtitleRepository>();
    builder.Services.AddScoped<IRepository<Creator>, CreatorRepository>();
    builder.Services.AddScoped<IRepository<GainedSkill>, GainedSkillRepository>();
    builder.Services.AddScoped<IRepository<Language>, LanguageRepository>();
    builder.Services.AddScoped<IRepository<Skill>, SkillRepository>();

    // Handlers
    builder.Services.AddTransient<UserEmailChangedIntegrationEventHandler>();
    builder.Services.AddTransient<UserNameChangedIntegrationEventHandler>();
    builder.Services.AddTransient<CreatorRegisteredIntegrationEventHandler>();
    builder.Services.AddTransient<CreatorDeletedIntegrationEventHandler>();

}
var app = builder.Build();
{
    // app.UseHttpsRedirection();

    app.UseCors();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseFastEndpoints(c =>
    {
        c.Serializer.Options.Converters.Add(new JsonStringEnumConverter());
    });

    app.UseSwaggerGen();

    var eventBus = app.Services.GetRequiredService<Infrastructure.EventBus.Generic.IEventBus>();
    eventBus.Subscribe<UserEmailChangedIntegrationEvent, UserEmailChangedIntegrationEventHandler>();
    eventBus.Subscribe<UserNameChangedIntegrationEvent, UserNameChangedIntegrationEventHandler>();
    eventBus.Subscribe<CreatorDeletedIntegrationEvent, CreatorDeletedIntegrationEventHandler>();
    eventBus.Subscribe<CreatorRegisteredIntegrationEvent, CreatorRegisteredIntegrationEventHandler>();
}
app.Run();
