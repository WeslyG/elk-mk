using System;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace SerilogHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .Enrich.WithProperty("Version", "1.0.0")
                    .Enrich.WithProperty("Task", "SerilogHelloWorld")
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://10.33.51.24:9200"))
                    {
                        // динамически создает индекс 
                        AutoRegisterTemplate = true,
                        // синтаксис для elk v6 (по умолчанию elk2)
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                        // имя индекса (lowercase)
                        IndexFormat = "INDEX_PATTERN_HERE"
                    })
                    .CreateLogger();

            for (var i = 0; i < 100; i++)
            {
                Log.Information("Server send status 200 for 30 ms from ip 10.33.51.24");
            }

            for (var i = 0; i < 50; i++)
            {
                Log.Warning("Server send status 404 for 30 ms from ip 10.33.51.24");
            }

            for (var i = 0; i < 10; i++)
            {
                Log.Error("Server send status 500 for 30 ms from ip 10.33.51.24");
            }

            Log.CloseAndFlush();
        }
    }
}
