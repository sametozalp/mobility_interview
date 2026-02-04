package com.ozalp.entity_management_spring.dataAccess;

import com.ozalp.entity_management_spring.models.entities.WebServiceOperation;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface WebServiceOperationRepository extends JpaRepository<WebServiceOperation, Integer> {
    List<WebServiceOperation> findByName(String name);
}
