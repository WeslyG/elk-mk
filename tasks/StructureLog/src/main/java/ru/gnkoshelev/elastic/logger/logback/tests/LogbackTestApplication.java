package ru.gnkoshelev.elastic.logger.logback.tests;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.MDC;
import java.util.Random;
import java.lang.Object;

/**
 * @author Gregory Koshelev
 */
public class LogbackTestApplication {
    private static Logger logger = LoggerFactory.getLogger(LogbackTestApplication.class);

    // Теперь повторим упраженение но уже на структурированных логах
    // но теперь вместо просто текста, мы будем рандомить значения в нужном
    // диапазоне, что бы было веселее

    // 100 сообщений "Server send status 200-210 for 1-200 ms from ip {random-ip}
    // and {RandomePlatform}" с типом Information
    // 50 сообщений "Server send status 400-451 for 1-200 ms from ip {random-ip} and
    // {RandomePlatform}" с типом Warning
    // 10 сообщений "Server send status 500-526 for 1-200 ms from ip {random-ip} and
    // {RandomePlatform}" с типом Error

    public static void main(String[] args) {
        for (int i = 0; i <= 100; i++) {
            String ipAdd = getRandomIpAddress();
            int requestTime = getRandomNumberInRange(10, 150);
            int statusCode = getRandomNumberInRange(200, 210);
            String platform = getRandomPlatform();
            MDC.put("requestTime", String.valueOf(requestTime));
            MDC.put("statusCode", String.valueOf(statusCode));
            MDC.put("platform", String.valueOf(platform));
            MDC.put("ipAddress", String.valueOf(ipAdd));
            // logger.info("Server send status {statusCode} for {requestTime} ms from ip {ipAddress} and {Platform}");
            String log = String.format("Server send status %2d for %2d ms from ip %s and %s", statusCode, requestTime, ipAdd, platform);
            logger.info(log);
        }
    }

    public static int getRandomNumberInRange(int min, int max) {
        Random r = new Random();
        return r.ints(min, (max + 1)).findFirst().getAsInt();
    }
    
    public static String getRandomIpAddress() {
        Random r = new Random();
        return r.nextInt(256) + "." + r.nextInt(256) + "." + r.nextInt(256) + "." + r.nextInt(256);
    }

    public static String getRandomPlatform() {
        String[] platforms = { "Windows 10", "Windows 7", "Windows Vista", "Windows XP", "Android", "MacOS" };
        int rnd = new Random().nextInt(platforms.length);
        return platforms[rnd];
    }
}
