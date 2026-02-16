
import { useEffect, useState } from 'react';
import { toast } from 'react-toastify';
import { Label } from 'semantic-ui-react';
import DataTable from '../../layouts/DataTable';
import EntityService from '../../services/entityService';

export default function EntityListContent() {

  const [results, setResults] = useState([])

  useEffect(() => {
    let service = new EntityService();
    service.getAllRecords().then(r => {
      setResults(r)
      toast.success("Success")
    })
  }, [])

  return (
    <div>
      <Label>Entity List</Label>
      <DataTable results={results}></DataTable>
    </div>
  )
}
