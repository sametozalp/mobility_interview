
import { useEffect, useState } from 'react';
import { toast } from "react-toastify";
import { Label } from 'semantic-ui-react';
import DataTable from '../../layouts/DataTable';
import WebService from '../../services/webService';

export default function WebListContent() {

  const [results, setResults] = useState([])

  useEffect(() => {
    let service = new WebService();
    service.getAllRecords().then(r => {
      setResults(r)
      toast.success("Success");
    })
  }, [])

  return (
    <div>
      <Label>Web List</Label>
      <DataTable results={results}></DataTable>
    </div>
  )
}
