import {
    Table,
    TableBody,
    TableCell,
    TableHeader,
    TableHeaderCell,
    TableRow
} from 'semantic-ui-react';

export default function DataTable({ results }) {
    return (
        <Table celled>
            <TableHeader>
                <TableRow>
                    <TableHeaderCell>Name</TableHeaderCell>
                    <TableHeaderCell>Surname</TableHeaderCell>
                    <TableHeaderCell>Age</TableHeaderCell>
                    <TableHeaderCell>Email</TableHeaderCell>
                    <TableHeaderCell>Phone Number</TableHeaderCell>
                </TableRow>
            </TableHeader>

            <TableBody>
                {
                    results.map(r => (
                        <TableRow>
                            <TableCell>{r.name}</TableCell>
                            <TableCell>{r.surname}</TableCell>
                            <TableCell>{r.age}</TableCell>
                            <TableCell>{r.email}</TableCell>
                            <TableCell>{r.phoneNumber}</TableCell>
                        </TableRow>
                    ))
                }
            </TableBody>
        </Table>)
}
