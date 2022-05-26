import React from "react";
import FizzBuzz from "./components/FizzBuzz";
import Header from "./components/Header";
//import Intervalos from "./components/Intervalos";
import NumerosFelizes from "./components/NumerosFelizes";
import PartidaDeTenis from "./components/PartidaDeTenis";


function App() {
  return (
    <>
      <div className="App">
        <header className="App-header">
          <Header />
      </header>
      </div>
      <div>
        <NumerosFelizes />
        <PartidaDeTenis />
        <FizzBuzz />
      </div>
    </>
  );
}

export default App;
