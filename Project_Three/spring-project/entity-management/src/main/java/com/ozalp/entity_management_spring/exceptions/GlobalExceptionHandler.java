package com.ozalp.entity_management_spring.exceptions;

import com.ozalp.entity_management_spring.business.service.LogEventService;
import jakarta.persistence.EntityNotFoundException;
import lombok.RequiredArgsConstructor;
import lombok.extern.slf4j.Slf4j;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;

import java.util.Map;

@RestControllerAdvice
@Slf4j
@RequiredArgsConstructor
public class GlobalExceptionHandler {

    private final LogEventService logEventService;

    @ExceptionHandler(EntityNotFoundException.class)
    ResponseEntity<?> handle(EntityNotFoundException e) {
        logEventService.sendLog("Entity Not Found: " + e.getLocalizedMessage());
        log.error("Entity Not Found: {}", e.getLocalizedMessage());
        return ResponseEntity.badRequest().body(Map.of("message", e.getLocalizedMessage()));
    }

    @ExceptionHandler(Exception.class)
    public ResponseEntity<Object> handleAllExceptions(Exception ex) {
        logEventService.sendLog("Internal Exception: " + ex.getLocalizedMessage());
        log.error("Internal Exception: {}", ex.getLocalizedMessage());
        return new ResponseEntity<>(Map.of("message", "An unknown error occurred"), HttpStatus.INTERNAL_SERVER_ERROR);
    }
}
