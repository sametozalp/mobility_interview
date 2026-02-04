package com.ozalp.entity_management_spring.business.mappers;

import com.ozalp.entity_management_spring.models.dtos.requests.CreateWebServiceOperationRequest;
import com.ozalp.entity_management_spring.models.dtos.responses.WebServiceOperationResponse;
import com.ozalp.entity_management_spring.models.entities.WebServiceOperation;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface WebServiceOperationMapper {

    WebServiceOperationResponse toResponse(WebServiceOperation myEntity);

    WebServiceOperation toEntity(CreateWebServiceOperationRequest request);
}
