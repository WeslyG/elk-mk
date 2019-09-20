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
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://elk-mk.dev.kontur.ru:9200"))
                    {
                        // Включает динамическое создание индекса
                        AutoRegisterTemplate = true,
                        // синтаксис для elk v6 (по умолчанию elk2)
                        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                        
                        // Не забудь поменять индекс паттерн на serilog-structure-{name}
                        IndexFormat = "INDEX_PATTERN_HERE"
                    })
                    .CreateLogger();

            // Теперь повторим упраженение но уже на структурированных логах
            // но теперь вместо просто текста, мы будем рандомить значения в нужном диапазоне, что бы было веселее

            // 100 сообщений "Server send status 200-210 for 1-200 ms from ip {random-ip} and {RandomePlatform}"  с типом Information
            // 50 сообщений "Server send status 400-451 for 1-200 ms from ip {random-ip} and {RandomePlatform}"  с типом Warning
            // 10 сообщений "Server send status 500-526 for 1-200 ms from ip {random-ip} and {RandomePlatform}" с типом Error

            // Вот так красиво можно писать в еластик. осталось понять, что передавать?
            WriteLogToElastic("????", Tuple.Create(????, ????), ????);
            WriteLogToElastic("????", Tuple.Create(????, ????), ????);
            WriteLogToElastic("????", Tuple.Create(????, ????), ????);

            // Ссылка на кибану
            // http://elk-mk.dev.kontur.ru:5601
            Log.CloseAndFlush();
        }

        //static string GetRandomIpAddress()
        //{
        //    var random = new Random(DateTime.Now.Millisecond);
        //    return $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";
        //}

        //static string GetRandomePlatforms()
        //{
        //    var platforms = new string[] {"Windows 10", "Windows 7", "Windows Vista", "Windows XP", "Android", "MacOS" };
        //    var rnd = new Random(DateTime.Now.Millisecond);
        //    int t = rnd.Next(0, platforms.Length);
        //    return platforms[t];
        //}

        //static void WriteLogToElastic(string logLevel, Tuple<int, int> statusCodeRange, int messageCount)
        //{
        //    for (var i = 0; i < messageCount; i++)
        //    {
        //        var random = new Random(DateTime.Now.Millisecond);
        //        int statusCode = random.Next(statusCodeRange.Item1, statusCodeRange.Item2);
        //        int time = random.Next(1, 250);

        //        string ip = GetRandomIpAddress();
        //        string platforms = GetRandomePlatforms();

        //        System.Threading.Tasks.Task.Delay(20).GetAwaiter().GetResult();

        //        switch (logLevel)
        //        {
        //            case "Error":
        //                Log.Error("Server send status {StatusCode} for {time} ms from ip {ip} and {Platforms}", statusCode, time, ip, platforms);
        //                break;
        //            case "Information":
        //                Log.Information("Server send status {StatusCode} for {time} ms from ip {ip} and {Platforms}", statusCode, time, ip, platforms);
        //                break;
        //            case "Warning":
        //                Log.Warning("Server send status {StatusCode} for {time} ms from ip {ip} and {Platforms}", statusCode, time, ip, platforms);
        //                break;
        //        }
        //    }
        //}
    }
}