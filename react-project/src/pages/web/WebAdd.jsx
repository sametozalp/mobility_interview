import { ErrorMessage, Field, Form, Formik } from "formik";
import { toast } from "react-toastify";
import { Button, FormField, Label } from 'semantic-ui-react';
import * as Yup from 'yup';
import WebService from '../../services/webService';

export default function WebAdd() {
    let initialValues = {
        name: "",
        surname: "",
        age: 0,
        email: "",
        phoneNumber: ""
    }

    const schema = Yup.object({
        name: Yup.string().required("Required"),
        surname: Yup.string().required("Required"),
        age: Yup.number().required("Required"),
        email: Yup.string().required("Required"),
        phoneNumber: Yup.string().required("Required"),
    })

    return (
        <Formik initialValues={initialValues} validationSchema={schema} onSubmit={(values, { resetForm }) => {
            let service = new WebService();
            service.addRecord(values).then(r => {
                resetForm();
                toast.success("Added.");
            })
        }}>
            <Form className="ui form">
                <FormField>
                    <Field name="name" placeholder="Name"></Field>
                    <ErrorMessage name="name" render={error =>
                        <Label pointing basic color="red" content={error}></Label>
                    }></ErrorMessage>
                </FormField>

                <FormField>
                    <Field name="surname" placeholder="Surname"></Field>
                    <ErrorMessage name="surname" render={error =>
                        <Label pointing basic color="red" content={error}></Label>
                    }></ErrorMessage>
                </FormField>

                <FormField>
                    <Field name="age" placeholder="Age"></Field>
                    <ErrorMessage name="age" render={error =>
                        <Label pointing basic color="red" content={error}></Label>
                    }></ErrorMessage>
                </FormField>

                <FormField>
                    <Field name="email" placeholder="Email"></Field>
                    <ErrorMessage name="email" render={error =>
                        <Label pointing basic color="red" content={error}></Label>
                    }></ErrorMessage>
                </FormField>

                <FormField>
                    <Field name="phoneNumber" placeholder="Phone Number"></Field>
                    <ErrorMessage name="phoneNumber" render={error =>
                        <Label pointing basic color="red" content={error}></Label>
                    }></ErrorMessage>
                </FormField>


                <Button color="green" type="submit">Add</Button>
            </Form>
        </Formik>
    )
}
