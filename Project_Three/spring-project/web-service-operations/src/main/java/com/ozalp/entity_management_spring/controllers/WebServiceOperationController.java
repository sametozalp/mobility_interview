package com.ozalp.entity_management_spring.controllers;

import com.ozalp.entity_management_spring.business.service.WebOperationService;
import com.ozalp.entity_management_spring.models.dtos.requests.CreateWebServiceOperationRequest;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/webService")
@RequiredArgsConstructor
@CrossOrigin(origins = "http://localhost:3000")
public class WebServiceOperationController {

    private final WebOperationService webOperationService;

    @PostMapping("/add")
    ResponseEntity<?> add(@RequestBody @Valid CreateWebServiceOperationRequest request) {
        webOperationService.add(request);
        return ResponseEntity.status(HttpStatus.CREATED).build();
    }

    @DeleteMapping("/delete/{name}")
    ResponseEntity<?> delete(@PathVariable(required = true) String name) {
        webOperationService.delete(name);
        return ResponseEntity.status(HttpStatus.NO_CONTENT).build();
    }

    @GetMapping("/search/{name}")
    ResponseEntity<?> search(@PathVariable(required = true) String name) {
        return ResponseEntity.ok(webOperationService.search(name));
    }

    @GetMapping("/list")
    ResponseEntity<?> list() {
        return ResponseEntity.ok(webOperationService.getAll());
    }
}
