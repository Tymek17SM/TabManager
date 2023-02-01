using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;
using WebAPI.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.InstallServicesInAssembly(builder.Configuration);

Serilog.Debugging.SelfLog.Enable(message => Console.WriteLine(message));

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticSearch:Uri"]))
    {
        TypeName = null,
        IndexFormat = $"{context.Configuration["ApplicationName"].ToLower()}-logs-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
        AutoRegisterTemplate = true,
        ModifyConnectionSettings = x => x.BasicAuthentication(
            context.Configuration["ElasticSearch:User"],
            context.Configuration["ElasticSearch:Password"]),
        NumberOfShards = 2,
        NumberOfReplicas = 1,

        EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog,
        MinimumLogEventLevel = Serilog.Events.LogEventLevel.Debug
    })
    .Enrich.WithProperty("Enviroment", context.HostingEnvironment.EnvironmentName)
    .ReadFrom.Configuration(context.Configuration);

});

builder.Host.UseMetricsWebTracking()
.UseMetrics(options =>
{
    options.EndpointOptions = endpointOptions =>
    {
        endpointOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
        
        endpointOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
        endpointOptions.EnvironmentInfoEndpointEnabled = false;
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
