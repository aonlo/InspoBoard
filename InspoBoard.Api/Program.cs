// WebApplicationBuilder with arguments passed from running
using InspoBoard.Api.Data;
using InspoBoard.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection 
// Add Db
builder.AddInspoBoardDb();
//   Adds controllers
builder.Services.AddControllers();
//   Adds OpenAPI - standardized description of API (documenting and testing)
//   https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Maps to endpoint with OpenAPI JSON document if running in development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Middleware to use HTTPS instead of HTTP
app.UseHttpsRedirection();

// Middleware to determine if user can access endpoints - [Authorize]
app.UseAuthorization();

// Activates route mapping for controllers - [Route("api/...")] maps to HTTP endpoints
app.MapControllers();

app.MigrateDb();

app.Run();