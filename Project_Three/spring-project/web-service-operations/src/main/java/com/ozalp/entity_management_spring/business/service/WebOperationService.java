package com.ozalp.entity_management_spring.business.service;

import com.ozalp.entity_management_spring.models.dtos.requests.CreateWebServiceOperationRequest;
import com.ozalp.entity_management_spring.models.dtos.responses.WebServiceOperationResponse;

import java.util.List;

public interface WebOperationService {

    void add(CreateWebServiceOperationRequest request);

    void delete(String name);

    List<WebServiceOperationResponse> getAll();

    List<WebServiceOperationResponse> search(String name);

}
