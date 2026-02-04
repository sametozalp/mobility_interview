package com.ozalp.entity_management_spring.dataAccess;

import com.ozalp.entity_management_spring.models.entities.Log;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface LogRepository extends JpaRepository<Log, Integer> {
}
