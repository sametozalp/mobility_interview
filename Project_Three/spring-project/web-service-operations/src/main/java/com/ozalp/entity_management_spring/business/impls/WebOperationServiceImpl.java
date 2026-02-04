package com.ozalp.entity_management_spring.business.impls;

import com.ozalp.entity_management_spring.business.mappers.WebServiceOperationMapper;
import com.ozalp.entity_management_spring.business.service.WebOperationService;
import com.ozalp.entity_management_spring.dataAccess.WebServiceOperationRepository;
import com.ozalp.entity_management_spring.models.dtos.requests.CreateWebServiceOperationRequest;
import com.ozalp.entity_management_spring.models.dtos.responses.WebServiceOperationResponse;
import com.ozalp.entity_management_spring.models.entities.WebServiceOperation;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@RequiredArgsConstructor
public class WebOperationServiceImpl implements WebOperationService {

    private final WebServiceOperationRepository repository;
    private final WebServiceOperationMapper mapper;

    @Override
    public void add(CreateWebServiceOperationRequest request) {
        WebServiceOperation reqEntity = mapper.toEntity(request);
        repository.save(reqEntity);
    }

    @Override
    public void delete(String name) {
        List<WebServiceOperation> myEntityList = repository.findByName(name);

        for (WebServiceOperation entity : myEntityList) {
            repository.delete(entity);
        }
    }

    @Override
    public List<WebServiceOperationResponse> getAll() {
        return repository.findAll()
                .stream()
                .map(mapper::toResponse)
                .toList();
    }

    @Override
    public List<WebServiceOperationResponse> search(String name) {
        return repository.findByName(name).stream()
                .map(mapper::toResponse)
                .toList();
    }
}
