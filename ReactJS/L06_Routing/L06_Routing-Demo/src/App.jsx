import { Routes, Route } from 'react-router';

import './App.css'

import Header from './components/Header'
import Home from './components/Home'
function App() {
   

    return (   
            <Header />
                  <Route path="/" element={<Home />} />
        
            
        </div>
    )
}

export default App
