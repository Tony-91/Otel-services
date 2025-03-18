using System;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;

class Program
{
    static void Main(string[] args)
    {
        // Set up OpenTelemetry SDK for logging
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddOpenTelemetry(options =>
            {
                options.AddOtlpExporter(o =>
                {
                    o.Endpoint = new Uri("http://localhost:55680");  // OTLP gRPC endpoint
                });
            });
        });

        // Create a logger instance
        var logger = loggerFactory.CreateLogger<Program>();

        // Log messages
        logger.LogInformation("This is an info log.");
        logger.LogError("This is an error log.");
        logger.LogDebug("This is a debug log.");
        logger.LogWarning("This is a warning log.");

        Console.WriteLine("Logs sent to OpenTelemetry Collector.");
    }
}
