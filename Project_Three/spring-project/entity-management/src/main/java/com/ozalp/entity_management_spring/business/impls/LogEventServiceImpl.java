package com.ozalp.entity_management_spring.business.impls;

import com.ozalp.entity_management_spring.business.service.LogEventService;
import com.ozalp.entity_management_spring.configs.RabbitMQConfig;
import lombok.RequiredArgsConstructor;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class LogEventServiceImpl implements LogEventService {

    private final RabbitTemplate rabbitTemplate;

    @Override
    public void sendLog(String message) {
        rabbitTemplate.convertAndSend(RabbitMQConfig.LOG_EXCHANGE, RabbitMQConfig.ROUTING_KEY, message);
    }
}
