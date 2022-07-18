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

// console.log(fileReader("./Caso de teste 1/c1_produtos.txt"));

/*

 let data = [
    [
      "Produto",
      "QtCO",
      "QtMin",
      "QtVendas",
      "Estq. após vendas",
      "Necess",
      "Transf. de Arm p/ CO",
    ],
    ["er","sdfs","sds" "Q", "E", "N", "T"],
    [texto, texto, texto, "Q", "E", "N", "T"],
  ];
*/

const outputHeaderData = (columns, row) => {
  return [[...columns], ...row];
};

// [
//   [ '36540', '16', '100', '1' ],
//   [ '26440', '2', '100', '3' ],
//   [ '16320', '1', '100', '2' ],
//   [ '16320', '53', '100', '3' ],
//   [ '36540', '174', '100', '3' ],
//   [ '26440', '120', '100', '2' ],
//   [ '23400', '50', '100', '2' ],
//   [ '36540', '62', '100', '3' ],
//   [ '28790', '36', '100', '2' ],
//   [ '36540', '29', '100', '4' ],
//   [ '16320', '18', '100', '4' ],
//   [ '31288', '1', '100', '3' ],
//   [ '28790', '58', '100', '1' ],
//   [ '16320', '26', '100', '3' ],
//   [ '23400', '330', '100', '2' ],
//   [ '28790', '80', '100', '1' ],
//   [ '23400', '125', '100', '1' ],
//   [ '23400', '117', '100', '3' ],
//   [ '23400', '79', '100', '1' ],
//   [ '16320', '30', '100', '1' ],
//   [ '28790', '71', '100', '3' ]
// ]

// [
//   [ '16320', '344', '200' ],
//   [ '23400', '1435', '500' ],
//   [ '26440', '2899', '800' ],
//   [ '28790', '310', '150' ],
//   [ '36540', '431', '100' ]
// ]

const sumSalesQuantities = (productCode, allProductSalesConfirmed) => {
  const sum = allProductSalesConfirmed
    .filter((productCodeFilter) => parseInt(productCodeFilter.split(";")[1]))
    .reduce((acc, item) => acc + item, 0);
};

const transfereWriterFile = (filename) => {
  const productsData = fileReader("./Caso de teste 1/c1_produtos.txt");
  const salesData = fileReader("./Caso de teste 1/c1_vendas.txt");
  const regexSemiColor = /\s*;\s*/;

  const products = productsData.split("\n");
  // .map((prod) => prod.split(regexSemiColor));

  const allProductSalesConfirmed = salesData
    .split("\n")
    .filter((a) => a.includes("100") || a.includes("102"));
  // .map((prod) => prod.split(regexSemiColor))
  // .filter((a) => a.includes("100") || a.includes("102"));

  products.map((prod, index) => {
    // sumSalesQuantities(prod.split(";")[0], allProductSalesConfirmed);

    const sum = allProductSalesConfirmed.filter((productCodeFilter) =>
      // productCodeFilter.split(";")[1] === prod.split(";")[0]
      console.log(productCodeFilter)
    );
    // .reduce((acc, item) => acc + item, 0);
  });

  // const data = outputHeaderData(
  //   [
  //     "Produto",
  //     "QtCO",
  //     "QtMin",
  //     "QtVendas",
  //     "Estq. após vendas",
  //     "Necess",
  //     "Transf. de Arm p/ CO",
  //   ],
  //   products
  // );

  // const config = {
  //   border: getBorderCharacters("norc"),
  //   columnDefault: {
  //     paddingLeft: 0,
  //     width: 10,
  //   },
  //   header: {
  //     alignment: "left",
  //     paddingLeft: 0,
  //     content: "Necessidade de Transferência Armazém para CO",
  //   },
  // };
  // let output = table(data, config);

  // fs.writeFile(filename, output, "utf8", (err) => {
  //   if (err) return console.log(err);
  //   console.log("The file was saved!");
  // });
};

transfereWriterFile("transfere.txt");
