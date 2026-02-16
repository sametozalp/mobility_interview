import { Grid } from 'semantic-ui-react';
import TopBar from "../layouts/TopBar";
import MyRouter from '../router/myRouter';
import MyMenu from "./MyMenu";

export default function Dashboard() {
    return (
        <div>
            <TopBar />

            <Grid columns={2}>
                <Grid.Row>
                    <Grid.Column width={5}>
                        <MyMenu />
                    </Grid.Column>
                    <Grid.Column width={11}>
                        <MyRouter />
                    </Grid.Column>
                </Grid.Row>
            </Grid>
        </div>
    )
}
