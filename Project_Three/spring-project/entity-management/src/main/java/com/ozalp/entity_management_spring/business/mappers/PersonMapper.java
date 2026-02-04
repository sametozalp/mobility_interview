package com.ozalp.entity_management_spring.business.mappers;

import com.ozalp.entity_management_spring.models.dtos.requests.CreatePersonRequest;
import com.ozalp.entity_management_spring.models.dtos.responses.PersonResponse;
import com.ozalp.entity_management_spring.models.entities.Person;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface PersonMapper {

    PersonResponse toResponse(Person myEntity);

    Person toEntity(CreatePersonRequest request);
}
