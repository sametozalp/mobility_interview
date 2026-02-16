import { ErrorMessage, Field, Form, Formik } from "formik";
import { toast } from "react-toastify";
import { Button, FormField, Label } from 'semantic-ui-react';
import * as Yup from 'yup';
import WebService from '../../services/webService';

export default function WebDelete() {
  let initialValues = {
    name: ""
  }

  const schema = Yup.object({
    name: Yup.string().required("Required")
  })

  return (
    <Formik initialValues={initialValues} validationSchema={schema} onSubmit={(values, { resetForm }) => {
      let service = new WebService();
      service.deleteRecord(values.name).then(r => {
        resetForm();
        toast.success("Removed data!");
      })
    }}>
      <Form className="ui form">
        <FormField>
          <Field name="name" placeholder="Name"></Field>
          <ErrorMessage name="name" render={error =>
            <Label pointing basic color="red" content={error}></Label>
          }></ErrorMessage>
        </FormField>

        <Button color="red" type="submit">Delete</Button>
      </Form>
    </Formik>
  )
}
