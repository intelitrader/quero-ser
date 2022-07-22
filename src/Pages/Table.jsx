import React from 'react';
import { Link } from 'react-router-dom';
import styled from '../Css/table.module.css';

function Table() {
  return(
    <>
      <header className={ styled.header}>
        <Link to="/" className={ styled.headerTitle }><h1>INTELITRADER</h1></Link>
      </header>
      <main className={ styled.mainContainer }>
        <table className={ styled.tableContainer}>
          <thead>
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
          </thead>
          <tbody>
            <tr>
              <td>Produto</td>
              <td>QtCO</td>
              <td>QtMin</td>
              <td>QtVendas</td>
              <td>Moeda</td>
              <td>Estq. após vendas</td>
              <td>Necess.</td>
              <td>Transf. de Arm p/ CO</td>
            </tr>
          </tbody>
        </table>
        <div className={ styled.downloadButtons }>
          <button>Baixar TRANSFERE.TXT</button>
          <button>Baixar DIVERGENCIAS.TXT</button>
          <button>Baixar TOTCANAIS.TXT</button>
        </div>
      </main>
      <footer className={ styled.footer }>
        <h2 className={ styled.footerText }>Desenvolvido por Matheus Marinho</h2>
      </footer>
    </>
  );
};

export default Table;
