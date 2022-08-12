async function loadFiles(products, vendas) {
  let text = await products.text();
  let text2 = await vendas.text();

  logFiles(text, text2);
}

function logFiles(productsString, salesString) {
  let productsArray = stringToArray(productsString);
  let salesArray = stringToArray(salesString);

  let confirmedSales = onlyConfirmedSales(productsArray, salesArray);

  let sortedSales = sortingConfirmedSales(confirmedSales);

  let transfereArray = creatingTransfereArray(productsArray, sortedSales);

  let divergencies = creatingDivergencies(productsArray, salesArray);

  let salesPerChannel = sortingChannelSales(confirmedSales);

  creatingTransferTable(transfereArray);
  creatingDivergenciesTable(divergencies);
  creatingSalesPerChannelTable(salesPerChannel);
}

/*Functions*/

function stringToArray(string) {
  let array = string.split(/\r?\n/);
  let returnedArray = [];

  for (let i = 0; i < array.length; i++) {
    returnedArray.push(array[i].split(';'));
  }

  return returnedArray;
}

function onlyConfirmedSales(productsArray, salesArray) {
  let productsCodes = [];
  let confirmedSales;
  productsArray.forEach(product => productsCodes.push(product[0]));
  //filtering vendasArray:
  let salesOk = salesArray.filter(vendas => productsCodes.includes(vendas[0]));
  confirmedSales = salesOk.filter(vendas => isConfirmed(vendas));
  return confirmedSales;
}

function isConfirmed(array) {
  return array[2] === '100' || array[2] === '102';
}

function sortingConfirmedSales(confirmedSales) {
  let sortedSales = {};

  confirmedSales.forEach(sale => {
    if (sortedSales[sale[0]]) {
      sortedSales[sale[0]] += Number.parseInt(sale[1]);
    } else {
      sortedSales[sale[0]] = Number.parseInt(sale[1]);
    }
  });

  return sortedSales;
}

function creatingTransfereArray(productsArray, sortedSales) {
  let transfere = [
    [
      'Produto',
      'QtCO',
      'QtMin',
      'QtVendas',
      'Estq.após Vendas',
      'Necess.',
      'Transf. de Arm p/ CO'
    ]
  ];

  productsArray.forEach(product => {
    if (product[0] !== '') {
      const codigo = product[0];
      const qtCo = product[1];
      const qtMin = product[2];
      const vendas = sortedSales[product[0]];
      const estoquePosVenda =
        Number.parseInt(product[1]) - sortedSales[product[0]];
      let necessidade = 0;

      if (estoquePosVenda < product[2]) {
        necessidade = product[2] - estoquePosVenda;
      }

      let transf = 0;

      if (necessidade > 0 && necessidade <= 10) {
        transf = 10;
      }
      if (necessidade > 10) {
        transf = necessidade;
      }

      transfere.push([
        codigo,
        qtCo,
        qtMin,
        vendas,
        estoquePosVenda,
        necessidade,
        transf
      ]);
    }
  });

  return transfere;
}

function creatingDivergencies(productsArray, vendasArray) {
  let productsCodes = [];
  let arrayFinal = [];

  productsArray.forEach(product => productsCodes.push(product[0]));

  vendasArray.forEach(array => {
    if (
      !productsCodes.includes(array[0]) &&
      array.length > 1 &&
      isConfirmed(array)
    ) {
      let index = vendasArray.findIndex(i => i === array) + 1;
      arrayFinal.push(
        `Linha ${index} - Código de produto não encontrado ${array[0]}`
      );
    } else if (!isConfirmed(array) && array.length > 1) {
      let index = vendasArray.findIndex(i => i === array) + 1;
      switch (array[2]) {
        case '135':
          arrayFinal.push(`Linha ${index} - Venda cancelada`);
          break;
        case '190':
          arrayFinal.push(`Linha ${index} - Venda não finalizada`);
          break;
        case '999':
          arrayFinal.push(
            `Linha ${index} - Erro desconhecido. Acionar equipe de TI`
          );
      }
    }
  });

  return arrayFinal;
}

function sortingChannelSales(confirmedSales) {
  let salesPerChannel = [
    ['1', 'Representantes', 0],
    ['2', 'Website', 0],
    ['3', 'App móvel Android', 0],
    ['4', 'App móvel Iphone', 0]
  ];

  confirmedSales.forEach(sale => {
    switch (sale[3]) {
      case '1':
        salesPerChannel[0][2] += Number.parseInt(sale[1]);
        break;
      case '2':
        salesPerChannel[1][2] += Number.parseInt(sale[1]);
        break;
      case '3':
        salesPerChannel[2][2] += Number.parseInt(sale[1]);
        break;
      case '4':
        salesPerChannel[3][2] += Number.parseInt(sale[1]);
    }
  });

  return salesPerChannel;
}

function creatingTransferTable(array) {
  let myTable = '<table><tr>';
  let perrow = 7; // CELLS PER ROW
  array.forEach(innerArray =>
    innerArray.forEach((value, i) => {
      myTable += `<td>${value}</td>`;
      // BREAK INTO NEXT ROW
      let next = i + 1;
      if (next % perrow == 0 && next != array.length) {
        myTable += '</tr><tr>';
      }
    })
  );
  // (C3) CLOSE THE TABLE STRING
  myTable += '</tr></table>';
  // (D) ATTACH HTML TO CONTAINER
  document.getElementById('transfer').innerHTML =
    'Necessidade de Transferência Armazém para CO' + myTable;
}

function creatingDivergenciesTable(array) {
  let myTable = '<table><tr>';
  let perrow = 1; // CELLS PER ROW
  array.forEach((value, i) => {
    myTable += `<td>${value}</td>`;
    // BREAK INTO NEXT ROW
    let next = i + 1;
    if (next % perrow == 0 && next != array.length) {
      myTable += '</tr><tr>';
    }
  });
  // (C3) CLOSE THE TABLE STRING
  myTable += '</tr></table>';
  console.log(myTable);
  // (D) ATTACH HTML TO CONTAINER
  document.getElementById('divergencies').innerHTML = myTable;
}

function creatingSalesPerChannelTable(array) {
  let myTable = '<table><tr>';
  let perrow = 3; // CELLS PER ROW
  array.forEach(innerArray =>
    innerArray.forEach((value, i) => {
      myTable += `<td>${value}</td>`;
      // BREAK INTO NEXT ROW
      let next = i + 1;
      if (next % perrow == 0 && next != array.length) {
        myTable += '</tr><tr>';
      }
    })
  );
  // (C3) CLOSE THE TABLE STRING
  myTable += '</tr></table>';
  // (D) ATTACH HTML TO CONTAINER
  document.getElementById('salesPerChannel').innerHTML =
    'Quantidades de Vendas por canal' + myTable;
}

// function file(array) {
//   var row_width = 40;

//   var content = '';
//   // array += 'Username' + new Array(row_width + 1).join(' ') + 'Password\n';
//   // array += '********' + new Array(row_width + 1).join(' ') + '********\n';

//   for (var i = 0; i < array.length; i += 2) {
//     content += array[i] + new Array(row_width - array[i].length + 9).join(' ');
//     content += array[i + 1];
//     content += '\n';
//   }

//   // Build a data URI:
//   uri = 'data:application/octet-stream,' + encodeURIComponent(content);

//   // Click on the file to download
//   // You can also do this as a button that has the href pointing to the data URI
//   location.href = uri;
// }

//----------------------------------------------------------------------
//using the fileSystem module in Node.js to access file system, read and manipulate files
//const fs = require('fs');

//let products1 = '';
//let vendas1 = '';
// function products(path) {
//   return fs.readFileSync(path, 'utf-8');
// }

// function sales(path) {
//   return fs.readFileSync(path, 'utf-8');
// }

// async function loadFileVendas(file) {
//   let vendas = await file.text();
//   return vendas;

//   //document.getElementById('output').textContent = text;
// }

//const vendas1 = sales('./Desafio/Caso de teste 2/c2_vendas.txt');
//const products1 = products('./Desafio/Caso de teste 2/c2_produtos.txt');

//array contendo os produtos:
//let productsArray1 = [];

//array contendo as vendas:
//let vendasArray1 = [];

//array contendo apenas as vendas confirmadas:
//let vendasConfirmadas = [];

//objeto contendo as vendas organizadas('códigoDoProduto':número de vendas)
//let vendasOrganizadas = {};

//array contendo as quantidades vendidas por canal de venda
// let vendasPorCanal = [
//   ['1', 'Representantes', 0],
//   ['2', 'Website', 0],
//   ['3', 'App móvel Android', 0],
//   ['4', 'App móvel Iphone', 0]
// ];

// const transfereHeader = [
//   'Produto',
//   'QtCO',
//   'QtMin',
//   'QtVendas',
//   'Estq.após Vendas',
//   'Necess.',
//   'Transf. de Arm p/ CO'
// ];

//array para a parte 1 do projeto
//console.log(creatingTransfereTxt(productsArray1));

//array para a parte 2 do projeto
//let divergencias = [];

//Criando os arrays dos produtos e das vendas:
//stringToArray(products1, productsArray1);
//stringToArray(vendas1, vendasArray1);
//console.log(productsArray1);
//console.log(vendasArray1);

//Criando o array vendasConfirmadas
//onlyConfirmedSales(productsArray1, vendasArray1);
//console.log(vendasConfirmadas);

//Organizando o array vendasConfirmadas
//sortingConfirmedSales(vendasConfirmadas);
//console.log(vendasOrganizadas);

//Adicionando as vendas ao transfere
//creatingTransfereTxt(productsArray1);
//console.table(creatingTransfereTxt(productsArray1));

//Criando arquivo de divergencias
//creatingDivergencias(productsArray1, vendasArray1);
//console.log(creatingDivergencias(productsArray1, vendasArray1));

//criando arquivo de vendas por canal
//sortingChannelSales(vendasConfirmadas);
//console.log(vendasPorCanal);

//fs.CreateTextFile('transfere.txt', true);

//changes completely the file
// fs.writeFile('./Desafio/resolução/teste.txt', content, err => {
//   if (err) {
//     console.error(err);
//     return;
//   }
// });

//fs.writeFile('./Desafio/resolução/teste2.txt', 'ultra2');

//add something to the file
// fs.appendFile('./Desafio/resolução/teste.txt', content, err => {
//   if (err) {
//     console.error(err);
//     return;
//   }
// })
//
