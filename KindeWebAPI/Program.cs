using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    // These two lines map the Kinde user ID to Identity.Name (optional).
    options.MapInboundClaims = false;
    options.TokenValidationParameters.NameClaimType = "sub";
  });

builder.Services
  .AddAuthorization(options =>
  {
    options.AddPolicy("ReadWeatherPermission",
      policy => policy.RequireAssertion(
        context => context.User.Claims.Any(c => c.Type == "permissions" && c.Value == "read:weather")
      ));
    options.AddPolicy("AdminRole",
      policy => policy.RequireAssertion(
        context => context.User.Claims.Any(c => c.Type == "roles" && c.Value == "admin")
      ));
  });

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

// Minimal API examples
app.MapGet("/Minimal/Public", () => "Hello world!");
app.MapGet("/Minimal/Protected", (ClaimsPrincipal user) => "Hello " + user?.Identity?.Name)
  .RequireAuthorization("ReadWeatherPermission");

app.Run();
