import React, { useState } from 'react';
import MyContext from './MyContext';

function Provider({children}) {
  const [productTxtList, setProductTxtList] = useState([]);
  const [salesTxtList, setSalesTxtList] = useState([]);
  const [productCodeList, setProductCodeList] = useState([]);

  const readTxt = (htmlElement, type) => {
    const input = htmlElement.files;
    const reader = new FileReader();
    const productCodesArray = [];
    const codesArray = [];
    reader.readAsText(input[0]);
    reader.onload = () => {
      const lines = reader.result.split(/\n/).filter((line) => line !== '');
      lines.forEach((line) => {
        const lineSplited = line.split(';');
        if(type === 'products') {
          const productsObj = {
            productCode: lineSplited[0],
            qtdInStock: lineSplited[1],
            qtdToStayInStock: lineSplited[2],
          };
          productCodesArray.push(lineSplited[0]);
          setProductCodeList(productCodesArray);
          codesArray.push(productsObj);
          setProductTxtList(codesArray);
        };
        if(type === 'sales') {
          const salesObj = {
            productCode: lineSplited[0],
            qtdSold: lineSplited[1],
            salesCode: lineSplited[2],
            sellChannel: lineSplited[3],
          };
          codesArray.push(salesObj);
          setSalesTxtList(codesArray);
        };
      });
    }
  }
  const context = {
    readTxt,
    productTxtList,
    salesTxtList,
    productCodeList
  };
  return (
    <MyContext.Provider value={ context }>
      { children }
    </MyContext.Provider>
  );
}

export default Provider;
