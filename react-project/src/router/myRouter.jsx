import { Route, Routes } from "react-router-dom";
import EntityAdd from "../pages/entity/EntityAdd";
import EntityDelete from "../pages/entity/EntityDelete";
import EntityListContent from "../pages/entity/EntityListContent";
import EntitySearch from "../pages/entity/EntitySearch";
import WebAdd from "../pages/web/WebAdd";
import WebDelete from "../pages/web/WebDelete";
import WebListContent from "../pages/web/WebListContent";
import WebSearch from "../pages/web/WebSearch";

export default function myRouter() {
    return (
        <div>
            <Routes>
                <Route exact path='/' element={<EntityListContent />} />

                <Route exact path='/entity/list' element={<EntityListContent />} />
                <Route exact path='/entity/add' element={<EntityAdd />} />
                <Route exact path='/entity/delete' element={<EntityDelete />} />
                <Route exact path='/entity/search' element={<EntitySearch />} />

                <Route exact path='/web/list' element={<WebListContent />} />
                <Route exact path='/web/add' element={<WebAdd />} />
                <Route exact path='/web/delete' element={<WebDelete />} />
                <Route exact path='/web/search' element={<WebSearch />} />
            </Routes>
        </div>
    )
}
