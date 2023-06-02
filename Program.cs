using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpoints.Security;
using CourseManagement;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Properties;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
{
    services.AddCors();

    services.AddFastEndpoints();
    services.AddJWTBearerAuth(builder.Configuration["JwtSecret"]);
    services.AddSwaggerDoc();

    services.Configure<IPConfig>(builder.Configuration.GetSection("IP"));


    string connectionString = builder.Configuration.GetSection("Database")["ConnectionString"];// Change to "MigrationConnection" when updating the database
    services.AddDbContext<CourseDbContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
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
}
app.Run();
