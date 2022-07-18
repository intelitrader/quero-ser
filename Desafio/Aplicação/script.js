var produtsObj = [];
var vendasObj = [];
const cabecalhos = {
  RelatorioDeTransferencia: {
    titulo: "Necessidade de Transferência Armazém para CO",
    cabecalho: [
      "Produtos",
      "QtCO",
      "QtMin",
      "QtVendas",
      "Estq.após Vendas",
      " Necess. ",
      "Transf. de Arm p/ CO",
    ],
  },
  RelaTorioDivergencia: {
    titulo: "Lista de Divergencias",
    cabecalho: ["Divergencias"],
  },
  RelatorioVendaDeCanais: {
    titulo: "Quantidades de Vendas por canal",
    cabecalho: ["Representantes", "WebSite", "Android", "Iphone"],
  },
  ListaDeVendas: {
    titulo: "Lista de Vendas",
    cabecalho: [
      "Linha",
      "Produto",
      "QtdVendida",
      "SituacaoDaVenda",
      "CanalDeVenda",
    ],
  },
  ListaDeProdutos: {
    titulo: "Lista de Produtos",
    cabecalho: ["Produtos", "QtCo", "Qtmin"],
  },
};
async function loadFileProdutos(file) {
  let data = await file.text();
  let dataString = "";
  dataString = data.split("\r\n");
  produtsObj = [];

  dataString.map((infoProduto) => {
    let stringToArray = infoProduto.split(";");
    produtsObj.push({
      Produto: parseInt(stringToArray[0]),
      QtCo: parseInt(stringToArray[1]),
      QtMin: parseInt(stringToArray[2]),
    });
  });
}

async function loadFileVendas(file) {
  let data = await file.text();
  let dataString = "";
  dataString = data.split("\r\n");
  vendasObj = [];
  dataString.map((infoProduto, index) => {
    let stringToArray = infoProduto.split(";");
    vendasObj.push({
      Linha: index + 1,
      Produto: parseInt(stringToArray[0]),
      QtdVendida: parseInt(stringToArray[1]),
      SituacaoDaVenda: parseInt(stringToArray[2]),
      CanalDeVenda: parseInt(stringToArray[3]),
    });
  });
}

function clean() {
  const table = document.querySelectorAll("table");
  Array.prototype.forEach.call(table, function (node) {
    node.parentNode.removeChild(node);
  });
}
function main() {
  clean();
  CriarTabela(produtsObj, cabecalhos.ListaDeProdutos);
  CriarTabela(vendasObj, cabecalhos.ListaDeVendas);
  CriarTabela(
    RelatorioDeTransferencia(vendasObj, produtsObj),
    cabecalhos.RelatorioDeTransferencia
  );
  CriarTabela(
    RelaTorioDivergencia(vendasObj, produtsObj),
    cabecalhos.RelaTorioDivergencia
  );
  CriarTabela(
    RelatorioPorCanais(vendasObj, produtsObj),
    cabecalhos.RelatorioVendaDeCanais
  );
}

function ListaDeProdutos(Infoprodutos) {
  let produtos = Infoprodutos.map((produto) => {
    return produto.Produto;
  });
  return produtos;
}

function RelatorioDeTransferencia(vendas, Infoprodutos) {
  const RelatorioDeNecessidadeDeTransf = Infoprodutos.map((produto) => {
    let vendasConfirmadas = 0;
    let qtdPosEstoque = 0;
    let necess = 0;
    let transDeArm = 0;

    vendas.map((venda) => {
      if (
        produto.Produto === venda.Produto &&
        (venda.SituacaoDaVenda === 100 || venda.SituacaoDaVenda === 102)
      ) {
        vendasConfirmadas += venda.QtdVendida;
        qtdPosEstoque = produto.QtCo - vendasConfirmadas;
        necess =
          produto.QtMin - qtdPosEstoque < 0 ? 0 : produto.QtMin - qtdPosEstoque;
        transDeArm = necess < 10 && necess != 0 ? 10 : necess;
      } else {
        return;
      }
    });
    return {
      Produto: produto.Produto,
      QtCo: produto.QtCo,
      QtMin: produto.QtMin,
      QtdVendida: vendasConfirmadas,
      PosVenda: qtdPosEstoque,
      Necess: necess,
      TransDeAr: transDeArm,
    };
  });
  return RelatorioDeNecessidadeDeTransf;
}

function CriarTabela(Relatorio, headers) {
  const body = document.querySelector("body");
  const table = document.createElement("table");
  body.appendChild(table);
  const cabecalho = document.createElement("tr");
  const titulo = document.createElement("tr");
  const test = document.createElement("th");
  table.appendChild(titulo);
  test.colSpan = headers.cabecalho.length;
  titulo.appendChild(test);
  test.appendChild(document.createTextNode(headers.titulo));
  headers.cabecalho.map((item) => {
    const header = document.createElement("th");
    cabecalho.appendChild(header);
    header.appendChild(document.createTextNode(item));
  });
  table.appendChild(cabecalho);
  if (Array.isArray(Relatorio)) {
    Relatorio.map((item, index) => {
      const linha = document.createElement("tr");
      table.appendChild(linha);
      Object.keys(item).map((key) => {
        const cell = document.createElement("td");
        linha.appendChild(cell);
        cell.appendChild(document.createTextNode(item[key]));
      });
    });
  } else {
    const linha = document.createElement("tr");
    table.appendChild(linha);
    Object.keys(Relatorio).map((key) => {
      const cell = document.createElement("td");
      linha.appendChild(cell);
      cell.appendChild(document.createTextNode(Relatorio[key]));
    });
  }
}

function RelaTorioDivergencia(vendas, Infoprodutos) {
  const Divergencias = [];
  vendas.map((venda, index) => {
    if (!ListaDeProdutos(Infoprodutos).includes(venda.Produto)) {
      Divergencias.push({
        ErroNEncontrado:
          "Linha " +
          (index + 1) +
          " - Código de Produto não encontrado " +
          venda.Produto,
      });
    }
    if (venda.SituacaoDaVenda === 135) {
      Divergencias.push({
        Erro135: "Linha " + (index + 1) + " - " + "Venda Cancelada",
      });
    }
    if (venda.SituacaoDaVenda === 190) {
      Divergencias.push({
        Erro190: "Linha " + (index + 1) + " - " + "Venda Não Finalizada",
      });
    }
    if (venda.SituacaoDaVenda === 999) {
      Divergencias.push({
        Erro999:
          "Linha " +
          (index + 1) +
          " - " +
          "Erro desconhecido. Acionar equipe de TI",
      });
    }
  });
  return Divergencias;
}

function RelatorioPorCanais(vendas, Infoprodutos) {
  var Representantes = 0;
  var Website = 0;
  var Android = 0;
  var iPhone = 0;
  vendas.map((venda) => {
    if (
      ListaDeProdutos(Infoprodutos).includes(venda.Produto) &&
      (venda.SituacaoDaVenda === 100 || venda.SituacaoDaVenda === 102)
    ) {
      switch (venda.CanalDeVenda) {
        case 1:
          Representantes += venda.QtdVendida;
          break;
        case 2:
          Website += venda.QtdVendida;
          break;
        case 3:
          Android += venda.QtdVendida;
          break;
        case 4:
          iPhone += venda.QtdVendida;
          break;
      }
    }
  });
  return {
    Representantes: Representantes,
    Website: Website,
    Android: Android,
    iPhone: iPhone,
  };
}
