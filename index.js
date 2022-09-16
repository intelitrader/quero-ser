const fs = require('fs');

const rawProductsData = fs.readFileSync('./Caso de teste 2/c2_produtos.txt', 'utf-8');
const rawSellsData = fs.readFileSync('./Caso de teste 2/c2_vendas.txt', 'utf-8');

const productsDataTreatment = (rawProducts) => {
    let namedProductsArray = []
    const productsArray = rawProducts.split('\n');
    productsArray.forEach((value) => namedProductsArray.push(productsClassAssignment(value)));
    // RETORNA PRODUTOS COMO OBJETO
    return namedProductsArray;
}

const sellsDataTreatment = (rawSells) => {
    let namedSellsArray = []
    const sellsArray = rawSells.split('\n');
    sellsArray.forEach((value) => namedSellsArray.push(sellsClassAssignment(value)));
    //  RETORNA VENDAS COMO OBJETO
    return namedSellsArray;
}

const productsClassAssignment = (products) => {
    const lineSplit = products.split(';');
    const prod = { code: lineSplit[0], quantStock: lineSplit[1], quantMinOperCenter: lineSplit[2] };

    return prod;
}

const sellsClassAssignment = (sells) => {
    const lineSplit = sells.split(';');
    const sell = { code: Number(lineSplit[0]), quantSell: Number(lineSplit[1]), sellSituation: Number(lineSplit[2]), sellChannel: Number(lineSplit[3]) };

    return sell;
}

const formatTableQtCo = (word) => {
    if (word.length > 3) {
        return `${word}    `
    } else {
        return `${word}     `
    }
}

const formatTableStck = (stockValue) => {
    if (stockValue.toString().length < 3) {
        return `${stockValue}              `
    } else if (stockValue.toString().length === 3) {
        return `${stockValue}             `
    } else if (stockValue.toString().length === 4) {
        return `${stockValue}            `
    }
}

const formatTableNeed = (needValue) => {
    if (needValue.toString().length === 1) {
        return `${needValue}            `
    } else if (needValue.toString().length === 2) {
        return `${needValue}           `
    } else if (needValue.toString().length === 3) {
        return `${needValue}          `
    } else {
        return `${needValue}          `
    }
}

const productsObjectArray = productsDataTreatment(rawProductsData);
const sellsObjectArray = sellsDataTreatment(rawSellsData);

const productsCode = productsObjectArray.map(value => Number(value.code));

const calcSellsQuantity = (productNumber) => {
    const convertedProductNumber = Number(productNumber);
    let sellSum = 0;
    sellsObjectArray.forEach((value) => {
        if (value.code === convertedProductNumber && (value.sellSituation === 100 || value.sellSituation === 102)) {
            sellSum += value.quantSell;
        }
    })
    return sellSum;
}

let transferArray = [];

productsObjectArray.forEach((value) => {
    const sellsQuantity = calcSellsQuantity(value.code);
    const stockAfterSells = Number(value.quantStock) - sellsQuantity;
    let stockTransferQuantity = 0;
    let stockTransferNecessity = stockTransferQuantity;
    const stockBalance = stockAfterSells - Number(value.quantMinOperCenter);

    if (stockBalance < -1 && stockBalance > -10) {
        stockTransferNecessity = Math.abs(stockBalance);
        stockTransferQuantity = 10;
    } else if (stockBalance <= 10) {
        stockTransferQuantity = Number(value.quantMinOperCenter) - stockAfterSells;
        stockTransferNecessity = stockTransferQuantity;
    }

    transferArray.push({
        produto: value.code,
        qtCo: value.quantStock,
        qtMin: value.quantMinOperCenter,
        qtVendas: sellsQuantity,
        estqPosVendas: stockAfterSells,
        necessidade: stockTransferNecessity,
        transf: stockTransferQuantity,
    })
})

const transferPrint =
    `Necessidade de Transferência Armazém para Centro Operacional (CO)

Produto     QtCO    QtMin   QtVendas      Estq. Após      Necess. Transf. de
                                          Vendas                  Arm p/ CO
${transferArray.map(value => value.produto + '       ' + formatTableQtCo(value.qtCo) + value.qtMin + '     ' + value.qtVendas + '           ' + formatTableStck(value.estqPosVendas) + formatTableNeed(value.necessidade) + value.transf).join('\n')}`

fs.writeFileSync('./outputs/transfer.txt', transferPrint);

const sellsCheck = (sellObj, sellIndex) => {
    if (!productsCode.includes(sellObj.code)) {
        return `Linha ${sellIndex + 1} - Código de Produto não encontrado ${sellObj.code} \n`;
    } else if (sellObj.sellSituation === 135) {
        return `Linha ${sellIndex + 1} - Venda cancelada \n`;
    } else if (sellObj.sellSituation === 190) {
        return `Linha ${sellIndex + 1} - Venda não finalizada \n`;
    } else if (sellObj.sellSituation === 999) {
        return `Linha ${sellIndex + 1} - Erro desconhecido. Acionar equipe de TI \n`;
    } else {
        return;
    }
}

const divergence =
    `${sellsObjectArray.map((value, index) => sellsCheck(value, index)).join('')}`;

fs.writeFileSync('./outputs/divergence.txt', divergence);

const channelsReportGenerator = (sellsArray) => {
    let representQuant = 0, websiteQuant = 0, androidApp = 0, iphoneApp = 0;
    let doneSellsArray = sellsArray.filter(value => (value.sellSituation === 100 || value.sellSituation === 102));
    doneSellsArray.forEach((value) => {
        if (value.sellChannel === 1) {
            representQuant += value.quantSell;
        } else if (value.sellChannel === 2) {
            websiteQuant += value.quantSell;
        } else if (value.sellChannel === 3) {
            androidApp += value.quantSell;
        } else if (value.sellChannel === 4) {
            iphoneApp += value.quantSell;
        }
    })

    return [representQuant, websiteQuant, androidApp, iphoneApp];
}

let [representQuant, websiteQuant, androidApp, iphoneApp] = channelsReportGenerator(sellsObjectArray);

const channelsReport =
    `Quantidades de Vendas por canal

1 - Representantes               ${representQuant}
2 - Website                      ${websiteQuant}
3 - App móvel Android            ${androidApp}
4 - App móvel Iphone             ${iphoneApp}
`;

fs.writeFileSync('./outputs/report.txt', channelsReport);
