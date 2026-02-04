package com.ozalp.entity_management_spring.business.service;

import com.ozalp.entity_management_spring.models.dtos.requests.CreatePersonRequest;
import com.ozalp.entity_management_spring.models.dtos.responses.PersonResponse;

import java.util.List;

public interface PersonService {

    void add(CreatePersonRequest request);

    void delete(String name);

    List<PersonResponse> getAll();

    List<PersonResponse> search(String name);

}
