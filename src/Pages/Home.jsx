import React from 'react';
import { Link, useHistory } from 'react-router-dom';

function Home() {
  const history = useHistory()
  return(
    <main>
      <header>
        <Link to="/"><h1>INTELITRADER</h1></Link>
      </header>
      <div>
        <h2>Insira o arquivo de produtos!</h2>
        <input type="file" accept="text/plain" className="input-produtos" />
      </div>
      <div>
        <h2>Insira o arquivo de produtos!</h2>
        <input type="file" accept="text/plain" className="input-vendas" />
      </div>
      <button onClick={ () => history.push('/table') }>Acessar Tabela</button>
    </main>
  );
};

export default Home;
