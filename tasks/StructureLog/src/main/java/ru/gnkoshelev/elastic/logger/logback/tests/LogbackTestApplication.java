package ru.gnkoshelev.elastic.logger.logback.tests;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.slf4j.MDC;

/**
 * @author Gregory Koshelev
 */
public class LogbackTestApplication {
    private static Logger logger = LoggerFactory.getLogger(LogbackTestApplication.class);

    public static void main(String[] args) {
        try (MDC.MDCCloseable ignored = MDC.putCloseable("user", "Gregory")) {
            for (int i = 0; i <= 100; i++) {
                MDC.put("iteration", String.valueOf(i));
                logger.info("I log {}", i);
            }
        }
    }
}
