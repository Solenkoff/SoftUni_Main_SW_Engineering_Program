import { Routes, Route } from 'react-router';

import './App.css'

import Header from './components/Header'
import Home from './components/Home'
import Contacts from './components/Contacts';
import Pricing from './components/Pricing';
import NotFound from './components/404';
function App() {
   

    return (   
            <Header />
                  <Route path="/" element={<Home />} />
                  <Route path="/pricing" element={<Pricing />} />
                  <Route path="/contacts" element={<Contacts />} />
                  <Route path="/*" element={<NotFound />} />
        
            
        </div>
    )
}

export default App
