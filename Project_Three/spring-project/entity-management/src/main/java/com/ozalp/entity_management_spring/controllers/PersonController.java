package com.ozalp.entity_management_spring.controllers;

import com.ozalp.entity_management_spring.business.service.PersonService;
import com.ozalp.entity_management_spring.models.dtos.requests.CreatePersonRequest;
import jakarta.validation.Valid;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/entity")
@RequiredArgsConstructor
@CrossOrigin(origins = "http://localhost:5173")
public class PersonController {

    private final PersonService personService;

    @PostMapping("/add")
    ResponseEntity<?> add(@RequestBody @Valid CreatePersonRequest request) {
        personService.add(request);
        return ResponseEntity.status(HttpStatus.CREATED).build();
    }

    @DeleteMapping("/delete/{name}")
    ResponseEntity<?> delete(@PathVariable(required = true) String name) {
        personService.delete(name);
        return ResponseEntity.status(HttpStatus.NO_CONTENT).build();
    }

    @GetMapping("/search/{name}")
    ResponseEntity<?> search(@PathVariable(required = true) String name) {
        return ResponseEntity.ok(personService.search(name));
    }

    @GetMapping("/list")
    ResponseEntity<?> list() {
        return ResponseEntity.ok(personService.getAll());
    }
}
