namespace FJM.Services.MobileDevice.API.Middleware
{
    public class ApiKeyMiddleware
    {
            private readonly RequestDelegate _next;
            private const string ApiKeyHeaderName = "ApiKey";
            private readonly string _apiKey;

            public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
            {
                _next = next;
                _apiKey = configuration["ApiKey"];
            }

            public async Task InvokeAsync(HttpContext context)
            {

            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context); return;
            }
            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized: API Key header is missing.");
                    return;
                }

                if (extractedApiKey != _apiKey)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized: API Key is invalid.");
                    return;
                }

                await _next(context);
            }
    }
}
