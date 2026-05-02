import { Routes, Route, BrowserRouter } from 'react-router-dom';
import Header from './components/Header';
import Home from './pages/Home';
import Tables from './pages/Tables';

function AppRoutes(){
    return(
        <BrowserRouter>
            <Header/>
            <Routes>
                <Route path='/' element={<Home/>}/>
                <Route path='/tables' element={<Tables/>}/>
            </Routes>
        </BrowserRouter>
    );
}

export default AppRoutes;