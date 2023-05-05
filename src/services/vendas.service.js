import { Vendas, VendasConfirmadas } from "../models/vendas.model.js";
import { criarArquivoDivergencias, criarArquivoTotcanais, criarArquivoTransfere } from "./arquivos.service.js";

export const registrarVendas = (listVendas) => {
  let arrayVendas = listVendas.trim().split("\r\n");
  let vendas = [];

  arrayVendas.forEach((produto) => {
    let dados = produto.split(";");
    try {
      if (dados[0] && dados[1] && dados[2] && dados[3])
        vendas.push(new Vendas(dados[0], parseInt(dados[1]), dados[2], dados[3]));

    } catch (err) {
      console.log(err);
    }
  });

  return vendas;
};

export const processarVendas = async (produtosList, vendasList) => {
  let produtos = produtosList;
  let vendas = vendasList;
  let divergencias = [];
  let vendasConfirmadas = [];
  let qtdVendasCanais = {
    representantes: 0,
    website: 0,
    appAndroid: 0,
    appIphone: 0
  };

  vendas.forEach((venda, index) => {
    if (venda.situacao == "100" || venda.situacao == "102") {
      const produto = produtos.filter(
        (prod) => prod.codigo == venda.codigoProd
      );
      if (produto.length > 0) {
        vendasConfirmadas = geraDadoDeVenda(vendasConfirmadas, produto[0], venda);

        switch (venda.canalCod) {
          case '1':
            qtdVendasCanais.representantes += venda.qtdVenda;
            break;
          case '2':
            qtdVendasCanais.website += venda.qtdVenda;
            break;
          case '3':
            qtdVendasCanais.appAndroid += venda.qtdVenda;
            break;
          case '4':
            qtdVendasCanais.appIphone += venda.qtdVenda;
            break;
          default:
            console.log("Canal de venda desconhecido!")
        }

        return;
      }
    }
    divergencias.push(processaErro(venda, index + 1));
  });

  await criarArquivoTransfere(vendasConfirmadas);
  await criarArquivoDivergencias(divergencias);
  await criarArquivoTotcanais(qtdVendasCanais);

};

const processaErro = (venda, linha) => {
  switch (venda.situacao) {
    case "135":
      return `Linha ${linha} – Venda cancelada`;
    case "190":
      return `Linha ${linha} – Venda não finalizada`;
    case "999":
      return `Linha ${linha} – Erro desconhecido. Acionar equipe de TI`;
    default:
      return `Linha ${linha} – Código de Produto não encontrado ${venda.codigoProd}`;
  }
};

const geraDadoDeVenda = (vendasConfirmadas, produto, venda) => {
  let arrayVendas = vendasConfirmadas;

  let vendaConfirmadaExiste = false;

  for (let i = 0; i < arrayVendas.length; i++) {
    if (arrayVendas[i].codigo == venda.codigoProd) {

      arrayVendas[i].qtdVendida = parseInt(arrayVendas[i].qtdVendida) + venda.qtdVenda;

      arrayVendas[i].qtdEstoqueAtual =
        arrayVendas[i].qtdEstoqueAtual - venda.qtdVenda;

      arrayVendas[i].qtdNecessaria = calculaQtdNecessariaParaRepor(
        arrayVendas[i].qtdMinima,
        arrayVendas[i].qtdEstoqueAtual,
      );

      arrayVendas[i].qtdTransf = calculaQtdParaTransferir(
        arrayVendas[i].qtdNecessaria
      );

      vendaConfirmadaExiste = true;

      break;
    }
  }

  if (!vendaConfirmadaExiste) {
    let qtdNecessaria = calculaQtdNecessariaParaRepor(
      produto.qtdMinima,
      produto.qtdEstoque,
      venda.qtdVenda
    );

    let qtdTransferencia = calculaQtdParaTransferir(qtdNecessaria);

    arrayVendas.push(
      new VendasConfirmadas(
        produto.codigo,
        produto.qtdEstoque,
        produto.qtdMinima,
        venda.qtdVenda,
        produto.qtdEstoque - venda.qtdVenda,
        qtdNecessaria,
        qtdTransferencia
      )
    );
  }

  return arrayVendas;
};

const calculaQtdNecessariaParaRepor = (qtdMinima, estoque, qtdVendas = 0) => {
  if (estoque < qtdMinima) {
    return qtdMinima - estoque - qtdVendas;
  }
  return 0;
};

const calculaQtdParaTransferir = (qtdNecessaria) => {
  if (qtdNecessaria > 0 && qtdNecessaria < 10) {
    return 10;
  }
  return qtdNecessaria;
};
