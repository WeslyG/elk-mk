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
                    .Enrich.WithProperty("Version", "2.0.0")
                    .Enrich.WithProperty("Task", "SerilogStructure")
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://10.33.51.24:9200"))
                    {
                        // динамически создает индекс 
                        AutoRegisterTemplate = true,
                        // синтаксис для elk v6 (по умолчанию elk2)
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                        // имя индекса (lowercase)
                        IndexFormat = "YOURE_INDEX_HERE"
                    })
                    .CreateLogger();

            Random random = new Random();

            for (var i = 0; i < 100; i++)
            {
                int statusSuccess = random.Next(200, 210);
                int time = random.Next(1, 200);
                string ip = GetRandomIpAddress();
                Log.Information("Server send status {StatusCode} for {time} ms from ip {ip}", statusSuccess, time, ip);
            }

            for (var i = 0; i < 50; i++)
            {
                int statusSuccess = random.Next(400, 451);
                int time = random.Next(200, 500);
                string ip = GetRandomIpAddress();
                Log.Warning("Server send status {StatusCode} for {time} ms from ip {ip}", statusSuccess, time, ip);
            }

            for (var i = 0; i < 10; i++)
            {
                int statusSuccess = random.Next(500, 526);
                int time = random.Next(1, 300);
                string ip = GetRandomIpAddress();
                Log.Error("Server send status {StatusCode} for {time} ms from ip {ip}", statusSuccess, time, ip);
            }
            Log.CloseAndFlush();
        }

        static string GetRandomIpAddress()
        {
            var random = new Random();
            return $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
        }
    }
}
