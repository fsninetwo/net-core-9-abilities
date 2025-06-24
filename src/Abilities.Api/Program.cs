using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
var swaggerSection = builder.Configuration.GetSection("Swagger");
var swaggerTitle = swaggerSection["Title"] ?? "API";
var swaggerVersion = swaggerSection["Version"] ?? "v1";

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(swaggerVersion, new OpenApiInfo { Title = swaggerTitle, Version = swaggerVersion });
});
builder.Services.AddControllers();
builder.Services.AddRazorComponents();
builder.Services.AddAntiforgery();

var app = builder.Build();

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    var jsonRoute = swaggerSection["JsonRoute"] ?? $"/swagger/{swaggerVersion}/swagger.json";
    var description = swaggerSection["Description"] ?? $"{swaggerTitle} {swaggerVersion}";
    app.UseSwaggerUI(c => c.SwaggerEndpoint(jsonRoute, description));
}

// Map controller endpoints
app.MapRazorComponents<Abilities.Ui.App>();
app.MapControllers().WithStaticAssets();

// Optimize static assets
app.MapStaticAssets();

// Antiforgery middleware (must be between routing and endpoints)
app.UseAntiforgery();

app.Run();

// This partial class is required so that the Program class can be referenced by test projects.
public partial class Program { } 