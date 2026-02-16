package com.ozalp.entity_management_spring.models.dtos.requests;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class CreatePersonRequest {

    private String name;

    private String surname;

    private int age;

    private String email;

    private String phoneNumber;

    private String occupation;

}
