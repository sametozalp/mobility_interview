package com.ozalp.entity_management_spring.models.dtos.responses;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class PersonResponse {

    private int id;

    private String name;

    private String surname;

    private int age;

    private String email;

    private String phoneNumber;

    private String occupation;

}
