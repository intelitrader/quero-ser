import React from 'react';
import { Link } from 'react-router-dom';
import styled from '../Css/table.module.css';

function Table() {
  return(
    <main>
      <header className={ styled.header}>
        <Link to="/"><h1>INTELITRADER</h1></Link>
      </header>
      <div className={ styled.tableContainer}>
        <tr>
            <th scope="col">Produto</th>
            <th scope="col">QtCO</th>
            <th scope="col">QtMin</th>
            <th scope="col">QtVendas</th>
            <th scope="col">Moeda</th>
            <th scope="col">Estq. após vendas</th>
            <th scope="col">Necess.</th>
            <th scope="col">Transf. de Arm p/ CO</th>
        </tr>
      </div>
      <div className={ styled.downloadButtons }>
        <button>Baixar TRANSFERE.TXT</button>
        <button>Baixar DIVERGENCIAS.TXT</button>
        <button>Baixar TOTCANAIS.TXT</button>
      </div>
      <footer className={ styled.footer }>
        <h2>Desenvolvido por <a href="https://www.linkedin.com/in/matheus-marinhodsp/">Matheus Marinho</a></h2>
      </footer>
    </main>
  );
};

export default Table;
