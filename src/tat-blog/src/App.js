import logo from './logo.svg';
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
import { Addon } from 'react-bootstrap/lib/InputGroup';
import AdminLayout from './Pages/Admin.js/Layout';
import Authors from './Pages/Admin.js/Authors';
import Categories from './Pages/Admin.js/Categories';
import Tags from './Pages/Admin.js/Tags';

function App() {
  return (
    <div >
      <Router>
        <Navbar/>
        <div className='container-fluid'>
          <div className='row'>
            <div className='col-9'>
              <Routes>
                <Route path='/' element={<Layout />}>
                  <Route path='/' element={<Index />}/>
                  <Route path='blog' element={<Index />} />
                  <Route path='blog/Contact' element={<Contact />} />
                  <Route path='blog/About' element={<About />} />
                  <Route path='blog/RSS' element={<RSS />}/>
                </Route>
                <Route path='/admin' element={<AdminLayout />} >
                  <Route path='/admin' element={<AdminIndex.default/>} />
                  <Route path='/admin/authors' element={<Authors/>} />
                  <Route path='/admin/categories' element={<Categories/>} />
                  <Route path='/admin/comments' element={<Comments/>} />
                  <Route path='/admin/posts' element={<Posts/>} />
                  <Route path='/admin/tags' element={<Tags/>} />
                </Route>
              </Routes>
            </div>
            <div className='col-3 border-start'>
              <Sidebar />
            </div>
          </div>
        </div>
        <Footer/>
      </Router>
    </div>
  );
}

export default App;
