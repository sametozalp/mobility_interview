package com.ozalp.entity_management_spring.business.impls;

import com.ozalp.entity_management_spring.business.mappers.PersonMapper;
import com.ozalp.entity_management_spring.business.service.PersonService;
import com.ozalp.entity_management_spring.dataAccess.PersonRepository;
import com.ozalp.entity_management_spring.models.dtos.requests.CreatePersonRequest;
import com.ozalp.entity_management_spring.models.dtos.responses.PersonResponse;
import com.ozalp.entity_management_spring.models.entities.Person;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class PersonServiceImpl implements PersonService {

    private final PersonRepository repository;
    private final PersonMapper mapper;

    @Override
    public void add(CreatePersonRequest request) {
        Person reqEntity = mapper.toEntity(request);
        repository.save(reqEntity);
    }

    @Override
    public void delete(String name) {
        List<Person> myEntityList = repository.findByName(name);

        for (Person entity : myEntityList) {
            repository.delete(entity);
        }
    }

    @Override
    public List<PersonResponse> getAll() {
        return repository.findAll()
                .stream()
                .map(mapper::toResponse)
                .toList();
    }

    @Override
    public List<PersonResponse> search(String name) {
        return repository.findByName(name).stream()
                .map(mapper::toResponse)
                .toList();
    }
}
