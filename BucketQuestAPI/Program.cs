using BucketQuestAPI;
using BucketQuestAPI.Data;
using Microsoft.EntityFrameworkCore;
using BucketQuestAPI.Extensions;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Options;
using Microsoft.CodeAnalysis.Options;
using MartinCostello.OpenApi;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddOpenApiExtensions(options => options.AddServerUrls = true);
builder.Services.AddAppServices(builder.Configuration);

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentityService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/openapi/v1.json", "BucketQuestAPI v1");
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(builder.Configuration["AllowedOrigins"] ?? throw new InvalidOperationException("AllowedOrigins not found")));

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var logger = services.GetRequiredService<ILogger<Program>>();
logger.LogInformation(builder.Configuration.GetConnectionString("DefaultConnection")); 
logger.LogInformation(builder.Configuration["GoogleClientId"]);
logger.LogInformation(builder.Configuration["GoogleClientSecret"]);

app.Run();
