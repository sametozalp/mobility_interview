package com.ozalp.entity_management_spring.consumers;

import com.ozalp.entity_management_spring.configs.RabbitMQConfig;
import com.ozalp.entity_management_spring.dataAccess.LogRepository;
import com.ozalp.entity_management_spring.models.entities.Log;
import lombok.RequiredArgsConstructor;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.stereotype.Service;

@Service
@RequiredArgsConstructor
public class LogConsumer {

    private final LogRepository repository;

    @RabbitListener(queues = RabbitMQConfig.LOG_QUEUE)
    public void consumeMessage(String message) {
        repository.save(new Log(message));
    }
}