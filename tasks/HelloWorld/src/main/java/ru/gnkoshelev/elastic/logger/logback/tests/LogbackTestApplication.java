package ru.gnkoshelev.elastic.logger.logback.tests;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * @author Gregory Koshelev
 */

public class LogbackTestApplication {
    private static Logger logger = LoggerFactory.getLogger(LogbackTestApplication.class);

    public static void main(String[] args) {

        //   Вот так можно записывать логи c разными разными уровнями
        // logger.info("Hello World");
        // logger.warn("Hello World");
        // logger.error("Hello World");

        // Задание, записать в эластик:
        // 100 сообщений "Server send status 200 for 30 ms from ip 192.168.1.1" с типом Information
        // 50 сообщений "Server send status 404 for 30 ms from ip 192.168.1.1" с типом Warning
        // 10 сообщений "Server send status 500 for 30 ms from ip 192.168.1.1" с типом Error

        // for (int i = 0; i < 100; i++) {
        //     logger.????("Server send status 200 for 30 ms from ip 192.168.1.1");
        // }

        // for (int i = 0; i < 50; i++) {
        //     logger.????("Server send status 404 for 30 ms from ip 192.168.1.1");
        // }

        // for (int i = 0; i < 10; i++) {
        //     logger.????("Server send status 500 for 30 ms from ip 192.168.1.1");
        // }

        // Посмотреть создался ли мой индекс можно так
        // http://46.163.163.75:9200/_cat/indices?v

        // Ссылка на кибану
        // http://46.163.163.75:5601
    }
}
