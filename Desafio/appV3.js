const fs = require("fs");
const { getBorderCharacters } = require("table");
const table = require("table").table;

const SALES_INPUT_ARGV = process.argv.slice(2)[0];
const PRODUCT_INPUT_ARGV = process.argv.slice(3)[0];

const product_path = __dirname + `${PRODUCT_INPUT_ARGV}`;
const sales_path = __dirname + `${SALES_INPUT_ARGV}`;

const fileReader = (caminho) =>
  fs.readFileSync(caminho, "utf-8", (error, data) => {
    if (error) console.log("Reading file failed" + error);
    return data;
  });

const outputHeaderData = (columns, row) => {
  return [[...columns], ...row];
};

const transfereWriterFile = (filename) => {
  const productsData = fileReader("./Caso de teste 1/c1_produtos.txt");
  const salesData = fileReader("./Caso de teste 1/c1_vendas.txt");
  const regexSemiColor = /\s*;\s*/;

  const products = productsData.split("\n");
  const allProductSalesConfirmed = salesData
    .split("\n")
    .filter((c) => c.includes("100") || c.includes("102"));

  const sumAllProductsConfirmedSalesById = (index) => {
    const productsCode = products.map((item) => item.split(regexSemiColor)[0]);
    return allProductSalesConfirmed
      .filter((b) => b.split(regexSemiColor)[0] === productsCode[index])
      .map((b) => parseInt(b.split(regexSemiColor)[1]))
      .reduce((accumulator, item) => accumulator + item, 0);
  };

  const stockAfterSale = (QtCO, QtVendas) => {
    return QtCO - QtVendas;
  };
  const isNeedToReplenishStock = (QtCO, QtMin, QtVendas, stockPosVendas) =>
    QtCO - QtVendas < QtMin ? QtMin - stockPosVendas : 0;

  const isNeedTransferFromTheWarehouseToTheCO = (necessTransference) =>
    necessTransference > 1 && necessTransference < 10 ? 10 : necessTransference;

  const addOnProductsListArray = (productsArr) => {
    for (let i = 0; i < productsArr.length; i++) {
      productsArr[i].push(sumAllProductsConfirmedSalesById(i));
      productsArr[i].push(
        stockAfterSale(parseInt(productsArr[i][1]), parseInt(productsArr[i][3]))
      );
      productsArr[i].push(
        isNeedToReplenishStock(
          parseInt(productsArr[i][1]),
          parseInt(productsArr[i][2]),
          parseInt(productsArr[i][3]),
          parseInt(productsArr[i][4])
        )
      );
      productsArr[i].push(
        isNeedTransferFromTheWarehouseToTheCO(parseInt(productsArr[i][5]))
      );
    }
    return productsArr;
  };
  const productWithAllFiedsFilled = addOnProductsListArray(
    products.map((prod) => prod.split(regexSemiColor))
  );
  const data = outputHeaderData(
    [
      "Produto",
      "QtCO",
      "QtMin",
      "QtVendas",
      "Estq. após vendas",
      "Necess",
      "Transf. de Arm p/ CO",
    ],
    productWithAllFiedsFilled
  );

  const config = {
    border: getBorderCharacters("norc"),
    columnDefault: {
      paddingLeft: 0,
      width: 10,
    },
    header: {
      alignment: "left",
      paddingLeft: 0,
      content: "Necessidade de Transferência Armazém para CO",
    },
  };
  let output = table(data, config);

  fs.writeFile(filename, output, "utf8", (err) => {
    if (err) return console.log(err);
    console.log("The transfere file was saved!");
  });
};

const divergencesWriterFile = (filename) => {
  const productsData = fileReader("./Caso de teste 1/c1_produtos.txt");
  const salesData = fileReader("./Caso de teste 1/c1_vendas.txt");
  const regexSemiColor = /\s*;\s*/;
  const productsID = productsData
    .split("\n")
    .map((item) => parseInt(item.split(regexSemiColor)[0]));
  const salesID = salesData
    .split("\n")
    .map((item) => parseInt(item.split(regexSemiColor)[0]));

  const valuesForDataTable = (arrayOfInfoForDataTable) => {
    const dataTableArrayValues = arrayOfInfoForDataTable.map(Object.values);
    
    dataTableArrayValues.forEach((item, index) => {
      dataTableArrayValues[index].push(
        `Linha ${item[0]} - ${item[1]} ${item.data ? item[2] : ""}`
        );
        console.log(item[0],item[1],item[2]);
        dataTableArrayValues[index] = dataTableArrayValues[index].slice(-1);
      });
      
      // console.log(arrayOfInfoForDataTable);
      // console.log(dataTableArrayValues);
    return "dataTableArrayValues";
  };

  const noProductCodeSimilarOnSales = (saleID, productID) => {
    const salesOnArrayDataFormat = salesData
      .split("\n")
      .map((item) => item.split(regexSemiColor));

    const noCodeOnProductAndSaleArray = saleID.filter(
      (item) => !productID.includes(item)
    );

    let info = [];
    salesOnArrayDataFormat.forEach((item, index) => {
      let indexID = item.some((itemSale) =>
        noCodeOnProductAndSaleArray
          .map((dataToString) => dataToString.toString())
          .includes(itemSale)
      );
      if (indexID) {
        info.push({
          line: index + 1,
          dataCode: parseInt(item),
        });
      }
    });
    info.map((item) => (item.message = "Código de Produto não encontrado"));
    return [...info];
    // const c = salesOnArrayDataFormat.filter((item) =>
    //   item.some((itemSale) =>
    //     noCodeOnProductAndSaleArray
    //       .map((dataToString) => dataToString.toString())
    //       .includes(itemSale)
    //   )
    // );
  };

  const saleSituationByIdCode = (situationCode) => {
    const salesSituations = salesData
      .split("\n")
      .map((item) => item.split(regexSemiColor)[2]);

    const situationsFiltered = salesSituations.filter(
      (situation) => situation === situationCode
    );

    let info = [];
    salesSituations.forEach((item, index) => {
      if (situationsFiltered.includes(item)) {
        info.push({ line: index + 1 });
      }
    });
    if (situationCode == "135")
      info.map((item) => (item.message = "Venda Cancelada"));
    if (situationCode === "190")
      info.map((item) => (item.message = "Venda não finalizada"));
    if (situationCode === "999")
      info.map(
        (item) => (item.message = "Erro desconhecido. Acionar equipe de TI")
      );

    return [...info];
  };

  const codeNotFounded = noProductCodeSimilarOnSales(salesID, productsID);
  const saleSituation135 = saleSituationByIdCode("135");
  const saleSituation190 = saleSituationByIdCode("190");
  const saleSituation999 = saleSituationByIdCode("999");

  const data = [` ${[...valuesForDataTable(codeNotFounded)]}`];

  // const dataTable = () => {};

  // const config = {
  //   columnDefault: {
  //     paddingLeft: 0,
  //     paddingRight: 1,
  //   },
  //   border: getBorderCharacters(`norc`),
  // };
  // let output = table(data, config);

  // fs.writeFile(filename, output, "utf8", (err) => {
  //   if (err) return console.log(err);
  //   console.log("The divergence file was saved!");
  // });
};

const totCanaisWriterFile = (filename) => {};

divergencesWriterFile("Divergencias.txt");
// transfereWriterFile("transfere.txt");
// totCanaisWriterFile("Totcanais.txt");
