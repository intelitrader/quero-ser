import React from 'react';
import { Link, useHistory } from 'react-router-dom';
import styled from '../Css/home.module.css';

function Home() {
  const history = useHistory()
  return(
    <main>
      <header className={ styled.header }>
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
      <footer className={ styled.footer }>
        <h2>Desenvolvido por <a href="https://www.linkedin.com/in/matheus-marinhodsp/">Matheus Marinho</a></h2>
      </footer>
    </main>
  );
};

export default Home;
