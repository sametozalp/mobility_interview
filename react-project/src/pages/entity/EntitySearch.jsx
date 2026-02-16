import { ErrorMessage, Field, Form, Formik } from "formik";
import { useState } from 'react';
import { toast } from "react-toastify";
import {
  Button, FormField, Label
} from 'semantic-ui-react';
import * as Yup from 'yup';
import DataTable from "../../layouts/DataTable";
import EntityService from '../../services/entityService';

export default function EntitySearch() {
  const [results, setResults] = useState([])

  let initialValues = {
    name: ""
  }

  const schema = Yup.object({
    name: Yup.string().required("Required")
  })

  return (
    <div>
      <Formik initialValues={initialValues} validationSchema={schema} onSubmit={(values, { resetForm }) => {
        let service = new EntityService();
        service.searchRecords(values.name).then(r => {
          setResults(r)
          toast.success("Success")
        })
      }}>
        <Form className="ui form">
          <FormField>
            <Field name="name" placeholder="Name"></Field>
            <ErrorMessage name="name" render={error =>
              <Label pointing basic color="red" content={error}></Label>
            }></ErrorMessage>
          </FormField>

          <Button color="purple" type="submit">Search</Button>
        </Form>
      </Formik>

      <div className="spacer" />

      <DataTable results={results}></DataTable>

    </div>
  )
}
