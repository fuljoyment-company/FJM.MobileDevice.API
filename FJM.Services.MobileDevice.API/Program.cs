using FJM.Services.MobileDevice.API.Middleware;
using FJM.Services.MobileDevice.BusinessLogic.Repositories;
using FJM.Services.MobileDevice.BusinessLogic.Services;
using FJM.Services.MobileDevice.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.ServiceModel;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
       
        //
        builder.Configuration
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables();
        builder.Services.AddDbContext<MobileDeviceDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("MobileDeviceCon")));
        var env = builder.Configuration["Environment"] ?? "Development";
        builder.Environment.EnvironmentName = env;
        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<IForMobileService, ForMobileService>();
        //Add services to the container.
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API with API Key Authentication",
                Version = "v1",
                Description = ""
            });
            //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
        // Add CORS services
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });
        var app = builder.Build();
        // Use API Key Middleware
       // app.UseMiddleware<ApiKeyMiddleware>();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Use CORS
        app.UseCors("AllowAllOrigins");

        app.MapControllers();
        app.Run();
    }
}
