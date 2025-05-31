using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.EntityFrameworkCore;
using Restaurent_Management.RestaurentManagement.Context;
using Restaurent_Management.RestaurentManagement.Services;
using RestSharp;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<restaurentManamentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);

builder.Services.AddTransient<IRestaurentManagementService, restaurentManagementService>();

builder.Services.AddTransient<IRestClientService, RestClientService>();







// ?? Retrieve Application Insights Instrumentation Key Once
var instrumentationKey = builder.Configuration["ApplicationInsights:InstrumentationKey"];
// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.ApplicationInsights(
        new TelemetryConfiguration(instrumentationKey),
        TelemetryConverter.Traces)
    .CreateLogger();


// Use Serilog as logging provider
builder.Host.UseSerilog();
builder.Services.AddSingleton(Log.Logger);
//register application insights
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["ApplicationInsights:InstrumentationKey"]);






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
