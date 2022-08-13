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
  let transfereTxt = creatingTransferTxt(transfereArray);

  let divergencies = creatingDivergencies(productsArray, salesArray);
  let divergenciesTxt = divergencies.join('\n');

  let salesPerChannel = sortingChannelSales(confirmedSales);
  let salesPerChannelTxt = creatingSalesPerChannelTableTxt(salesPerChannel);

  creatingTransferTable(transfereArray, transfereTxt);
  creatingDivergenciesTable(divergencies, divergenciesTxt);
  creatingSalesPerChannelTable(salesPerChannel, salesPerChannelTxt);
}

/*Functions*/

function creatingTransferTxt(array) {
  //console.log(array);
  let transferTxt = [];
  let transferTxtReady = [];

  //criando espaçamento entre os itens
  for (let i = 0; i < array.length; i++) {
    let newInnerArray = [];
    for (let j = 0; j < array[i].length; j++) {
      if (typeof array[i][j] === 'string') {
        let newCell = array[i][j].padStart(20, ' ');
        newInnerArray.push(newCell);
      } else {
        let newCell = array[i][j].toString().padStart(20, ' ');
        newInnerArray.push(newCell);
      }
    }
    transferTxtReady.push(newInnerArray);
  }

  transferTxtReady.forEach(array => {
    array = array.join(' ');
    transferTxt.push(array);
  });
  transferTxt.unshift('Necessidade de Transferencia Armazem para CO');

  transferTxt = transferTxt.join('\n');

  return transferTxt;
}

function creatingSalesPerChannelTableTxt(array) {
  let firstArray = [];
  let salesPerChannelTxt = [];

  for (let i = 0; i < array.length; i++) {
    let newInnerArray = [];
    for (let j = 0; j < array[i].length; j++) {
      if (typeof array[i][j] === 'string') {
        let newCell = array[i][j].padStart(20, ' ');
        newInnerArray.push(newCell);
      } else {
        let newCell = array[i][j].toString().padStart(20, ' ');
        newInnerArray.push(newCell);
      }
    }
    firstArray.push(newInnerArray);
  }

  firstArray.forEach(sale => {
    sale = sale.join(',');
    sale = sale.replace(',', '-');
    salesPerChannelTxt.push(sale);
  });

  salesPerChannelTxt.unshift(
    '                    Canal                                     Vendas'
  );
  salesPerChannelTxt.unshift('Quantidades de Vendas por canal');

  salesPerChannelTxt = salesPerChannelTxt.join('\n');
  salesPerChannelTxt = salesPerChannelTxt.replaceAll(',', '    ');

  return salesPerChannelTxt;
}

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

function creatingTransferTable(array, stringToTxtFile) {
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
    '<h2>Necessidade de Transferência Armazém para CO</h2>' + myTable;

  let div = document.querySelector('.generateFile.transferFile');
  div.style.display = 'inline-block';

  let btnCreateFileTransfer = document.querySelector('#btnCreateFileTransfer');

  btnCreateFileTransfer.addEventListener(
    'click',
    function () {
      var link = document.getElementById('downloadFileTransfer');
      link.href = generateTxtFile(stringToTxtFile);
      link.style.display = 'inline-block';
    },
    false
  );

  document
    .querySelector('#downloadFileTransfer')
    .addEventListener('click', event => {
      event.currentTarget.style.display = 'none';
    });
}

function creatingSalesPerChannelTable(array, stringToTxtFile) {
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
    '<h2>Quantidade de Vendas por Canal</h2>' + myTable;

  let div = document.querySelector('.generateFile.salesPerChannelFile');
  div.style.display = 'inline-block';

  let btnCreateFileSalesPerChannel = document.querySelector(
    '#btnCreateFileSalesPerChannel'
  );

  btnCreateFileSalesPerChannel.addEventListener(
    'click',
    function () {
      var link = document.getElementById('downloadFileSalesPerChannel');
      link.href = generateTxtFile(stringToTxtFile);
      link.style.display = 'inline-block';
    },
    false
  );

  document
    .querySelector('#downloadFileSalesPerChannel')
    .addEventListener('click', event => {
      event.currentTarget.style.display = 'none';
    });
}

function creatingDivergenciesTable(array, stringToTxtFile) {
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

  // (D) ATTACH HTML TO CONTAINER
  document.getElementById('divergencies').innerHTML =
    '<h2>Divergências Encontradas</h2>' + myTable;

  let div = document.querySelector('.generateFile.divergenciesFile');
  div.style.display = 'inline-block';

  let btnCreateFileDivergencies = document.querySelector(
    '#btnCreateFileDivergencies'
  );

  btnCreateFileDivergencies.addEventListener(
    'click',
    function () {
      var link = document.getElementById('downloadFileDivergencies');
      link.href = generateTxtFile(stringToTxtFile);
      link.style.display = 'inline-block';
    },
    false
  );

  document
    .querySelector('#downloadFileDivergencies')
    .addEventListener('click', event => {
      event.currentTarget.style.display = 'none';
    });
}

function generateTxtFile(text) {
  var textFile = null;
  var data = new Blob([text], { type: 'text/plain' });
  if (textFile !== null) {
    window.URL.revokeObjectURL(textFile);
  }
  textFile = window.URL.createObjectURL(data);
  return textFile;
}
