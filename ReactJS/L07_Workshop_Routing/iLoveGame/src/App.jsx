import Header from "./components/header/Header"
import Footer from "./components/footer/Footer"
import Home from "./components/home/Home"
import { Route, Routes } from "react-router"
import Catalog from "./components/catalog/Catalog"
import GameDetails from "./components/game-details/GameDetails"

function App() {

    return (
        <>
        
            <Header />

            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/catalog" element={<Catalog />} />
                <Route path="/games/:gameId" element={<GameDetails />} />
            </Routes>

            <Footer />

        </>

    )
}

export default App
