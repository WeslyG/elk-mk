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
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://elk-mk.dev.kontur.ru:9200"))
                    {
                        // динамически создает индекс 
                        AutoRegisterTemplate = true,
                        // синтаксис для elk v6 (по умолчанию elk2)
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,

                        // Впиши имя индекса сюда в формате serilog-hello-{youreName} 
                        // LowerCase need!
                        IndexFormat = "INDEX_PATTERN_HERE"
                    })
                    .CreateLogger();

            // Вот так можно записывать логи разными типами
            // Обрати внимание что метода info нет, только information
            // Log.Information("Hello World");
            // Log.Warning("Hello World");
            // Log.Error("Hello World");

            // Твое задание, записать:
            // 100 сообщений "Server send status 200 for 30 ms from ip 10.33.51.24" с типом Information
            // 50 сообщений "Server send status 404 for 30 ms from ip 10.33.51.24" с типом Warning
            // 10 сообщений "Server send status 500 for 30 ms from ip 10.33.51.24" с типом Error

            // for (var i = 0; i < ??; i++)
            // {
            //     Log.????("Server send status 200 for 30 ms from ip 10.33.51.24");
            // }

            // for (var i = 0; i < ??; i++)
            // {
            //     Log.????("Server send status 404 for 30 ms from ip 10.33.51.24");
            // }

            // for (var i = 0; i < ??; i++)
            // {
            //     Log.????("Server send status 500 for 30 ms from ip 10.33.51.24");
            // }

            // Посмотреть создался ли мой индекс можно так
            // http://elk-mk.dev.kontur.ru:9200/_cat/indices?v

            // Ссылка на кибану вот
            // http://elk-mk.dev.kontur.ru:5601


            Log.CloseAndFlush();
        }
    }
}