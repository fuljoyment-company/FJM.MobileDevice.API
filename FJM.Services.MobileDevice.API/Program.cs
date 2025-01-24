using FJM.Services.MobileDevice.API.Middleware;
using fuljoymentMobileServiceBinder.Interface;
using fuljoymentMobileServiceBinder.Services;
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

        var env = builder.Configuration["Environment"] ?? "Development";
        builder.Environment.EnvironmentName = env;

        //Checking Environment
        if (env == "Production")
        {
            builder.Services.AddScoped(_ => new SSLfuljoymentMobileService.ForMobilesClient(
                SSLfuljoymentMobileService.ForMobilesClient.EndpointConfiguration.BasicHttpBinding_IForMobiles,
                new EndpointAddress("https://www.fuljoyment.com/forMobiles/Android2024/ForMobiles.svc")));

            builder.Services.AddScoped<IForMobilesService>(provider =>
            {
                var client = provider.GetRequiredService<SSLfuljoymentMobileService.ForMobilesClient>();
                return new SslfuljoymentMobileServiceAdapter(client); // Ensure this adapter implements IForMobilesService
            });
        }
        else if (env == "Development")
        {
            builder.Services.AddScoped(_ => new TestfuljoymentMobileService.ForMobilesClient(
                TestfuljoymentMobileService.ForMobilesClient.EndpointConfiguration.BasicHttpBinding_IForMobiles,
                new EndpointAddress("https://www.fuljoyment.com/forMobiles/202001test/ForMobiles.svc")));

            builder.Services.AddScoped<IForMobilesService>(provider =>
            {
                var client = provider.GetRequiredService<TestfuljoymentMobileService.ForMobilesClient>();
                return new TestfuljoymentMobileServiceAdapter(client); 
            });
        }
        else
        {
            throw new InvalidOperationException($"Unknown environment: {env}");
        }
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
        app.UseMiddleware<ApiKeyMiddleware>();
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
