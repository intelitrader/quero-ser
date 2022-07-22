import React from 'react';
import { Link, useHistory } from 'react-router-dom';
import styled from '../Css/home.module.css';

function Home() {
  const history = useHistory()
  return(
    <>
      <header className={ styled.header }>
        <Link to="/" className={ styled.headerTitle }><h1>INTELITRADER</h1></Link>
      </header>
      <main className={ styled.mainContainer }>
        <div className={ styled.inputContainer }>
          <div>
            <h2>Insira o arquivo de produtos!</h2>
            <input type="file" accept="text/plain" />
          </div>
          <div>
            <h2>Insira o arquivo de vendas!</h2>
            <input type="file" accept="text/plain"  />
          </div>
        </div>
        <button onClick={ () => history.push('/table') } className={ styled.tableButton }>Acessar Tabela</button>
      </main>
      <footer className={ styled.footer }>
        <h2 className={ styled.footerText }>Desenvolvido por Matheus Marinho</h2>
      </footer>
    </>
  );
};

export default Home;
