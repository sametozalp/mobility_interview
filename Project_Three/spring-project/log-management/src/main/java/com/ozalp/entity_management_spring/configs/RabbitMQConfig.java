package com.ozalp.entity_management_spring.configs;

import org.springframework.amqp.core.Binding;
import org.springframework.amqp.core.BindingBuilder;
import org.springframework.amqp.core.DirectExchange;
import org.springframework.amqp.core.Queue;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class RabbitMQConfig {

    public static final String LOG_EXCHANGE = "log.exchange";
    public static final String LOG_QUEUE = "log.queue";
    public static final String ROUTING_KEY = "log";

    @Bean
    public DirectExchange logExchange() {
        return new DirectExchange(
                LOG_EXCHANGE,
                true,
                true
        );
    }

    @Bean
    public Queue logQueue() {
        return new Queue(LOG_QUEUE, true);
    }

    @Bean
    public Binding binding(Queue queue, DirectExchange exchange) {
        return BindingBuilder.bind(queue).to(exchange).with(ROUTING_KEY);
    }
}