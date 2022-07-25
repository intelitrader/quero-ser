import React, { useContext, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import MyContext from '../Context/MyContext';
import styled from '../Css/table.module.css';
import {verifySales, downloadFile, makeTransferFile } from '../helpers';

function Table() {
  const { salesTxtList, productTxtList, productCodeList } = useContext(MyContext);
  const [divergencyFile, setDivergencyFile] = useState('');
  const [filtredSales, setFiltredSales] = useState([]);
  const [transferFile, setTransferFile] = useState('');
  useEffect(() => {
    verifySales(salesTxtList, productCodeList, setDivergencyFile, setFiltredSales, productTxtList);
  }, []);
  useEffect(() => {
    setTransferFile(makeTransferFile(filtredSales));
  }, [filtredSales]);

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
                <th scope="col">Estq. após vendas</th>
                <th scope="col">Necess.</th>
                <th scope="col">Transf. de Arm p/ CO</th>
            </tr>
          </thead>
          <tbody>
            { filtredSales.length > 0 && (
              filtredSales.map((sale, index) => (
                <tr key={ index }>
                  <td>{ sale.productCode }</td>
                  <td>{ sale.qtdCO }</td>
                  <td>{ sale.qtdMin }</td>
                  <td>{ sale.qtdSold }</td>
                  <td>{ sale.stock }</td>
                  <td>{ sale.nessToRepo }</td>
                  <td>{ sale.qtdToTransfer }</td>
                </tr>
              ))
            )}
          </tbody>
        </table>
        <div className={ styled.downloadButtons }>
          <button onClick={ () => downloadFile(transferFile, 'TRANSFERE') }>Baixar TRANSFERE.TXT</button>
          <button onClick={ () => downloadFile(divergencyFile, 'DIVERGENCIAS') }>Baixar DIVERGENCIAS.TXT</button>
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
