package com.ozalp.entity_management_spring.models.entities;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table(name = "logs")
@NoArgsConstructor
@AllArgsConstructor
@Getter
@Setter
public class Log extends BaseEntity {

    @Column(name = "details", nullable = false, columnDefinition = "TEXT")
    private String details;

}
