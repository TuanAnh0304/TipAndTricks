import './App.css';
import Navbar from './Components/Navbar';
import Sidebar from './Components/Sidebar';
import Footer from './Components/Footer';
import Layout from './Pages/Layout';
import Index from './Pages/Index';
import About from './Pages/About';
import Contact from './Pages/Contact';
import RSS from './Pages/RSS';

import{
  BrowserRouter as Router,
  Routes,
  Route,
} from 'react-router-dom';
import * as AdminIndex from './Pages/Admin/Index';
import AdminLayout from './Pages/Admin/Layout';
import Authors from './Pages/Admin/Authors';
import Categories from './Pages/Admin/Categories';
import Tags from './Pages/Admin/Tags';
import Posts from './Pages/Admin/Post/Posts';
import Comments from './Pages/Admin/Comments';

import NotFound from './Pages/NotFound';
import BadRequest from './Pages/BadRequest';


function App() {
  return (
    <div >
      <Router>
        <div className='container-fluid'>
          <div className='row'>
            <div className='col-9'>
              <Routes>
                <Route path='/admin' element={<AdminLayout />} >
                  <Route path='/admin' element={<AdminIndex.default/>} />
                  <Route path='/admin/authors' element={<Authors/>} />
                  <Route path='/admin/categories' element={<Categories/>} />
                  <Route path='/admin/comments' element={<Comments/>} />
                  <Route path='/admin/posts' element={<Posts/>} />
                  <Route path='/admin/tags' element={<Tags/>} />
                </Route>
                <Route path='/400' element={<BadRequest />} />
                <Route path='*' element={<NotFound />} />
              </Routes>
            </div>
            <div className='col-3 border-start'>
              <Sidebar />
            </div>
          </div>
        </div>
      </Router>
    </div>
  );
}

export default App;
