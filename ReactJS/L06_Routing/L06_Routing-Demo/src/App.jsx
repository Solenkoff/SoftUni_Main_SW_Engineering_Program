import { Routes, Route } from 'react-router';

import './App.css'

import Header from './components/Header'
import Home from './components/Home'
import Contacts from './components/Contacts';
import Pricing from './components/Pricing';
import NotFound from './components/404';
import Catalog from './components/Catalog';
import ProductDetails from './components/ProductDetails';

   
function App() {
   
    return (   
        <div className="bg-white">
            <Header />

            <Routes>
                  <Route path="/" element={<Home />} />
                  <Route path="/catalog" element={<Catalog />} />
                  <Route path="/catalog/:productId" element={<ProductDetails />} />
                  <Route path="/pricing" element={<Pricing />} />
                  <Route path="/contacts" element={<Contacts />} />
                  <Route path="/*" element={<NotFound />} />
            </Routes>
        
        </div>
    )
}

export default App
