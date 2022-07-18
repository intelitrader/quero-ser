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
  // .map((prod) => prod.split(regexSemiColor));

  const allProductSalesConfirmed = salesData
    .split("\n")
    // .map((prod) => prod.split(regexSemiColor))
    .filter((c) => c.includes("100") || c.includes("102"));

  const newArray = products.map((prod, index) => {
    let productsID = prod.split(regexSemiColor)[0];

    let qtSalesTotal = allProductSalesConfirmed
      .filter((d) => d.split(regexSemiColor)[0] === productsID)
      .map((quantity) => parseInt(quantity.split(regexSemiColor)[1]))
      .reduce((accumulator, item) => accumulator + item, 0);

    return { productsID, qtSalesTotal };
  });

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
  const productAdded = addOnProductsListArray(
    products.map((prod) => prod.split(regexSemiColor))
  );
  console.log(productAdded);

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
    productAdded
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
    console.log("The file was saved!");
  });
};

transfereWriterFile("transfere.txt");
