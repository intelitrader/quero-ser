import { appendFile, existsSync, mkdirSync, readdir, readFile } from "fs";

export const lerArquivo = async (caminho) => {
  let promise = new Promise((resolve, reject) => {
    readFile(caminho, (err, data) => {
      err ? reject(err) : resolve(data);
    });
  })
    .then((data) => data.toString())
    .catch((err) => console.log(err));

  return await promise;
};

export const retornaTodosArquivos = async (caminho) => {
  let promise = await new Promise((resolve, reject) => {
    readdir(caminho, (err, files) => {
      err ? reject(err) : resolve(files);
    });
  }).catch((err) => console.log(err));

  return promise;
};

export const criarArquivoTransfere = async (vendas) => {
  await criarDiretorioResultado();

  if (vendas.length > 0) {
    let conteudo = `=============================== \n`;
    conteudo += `Produto   QtCO      QtMin     QtVendas  Estq.Atual Necess.  Transf. de Arm p/ CO\n\n`;

    vendas.forEach((venda) => {
      conteudo += `${venda.codigo} ${adicionaEspacos(venda.codigo)}`;
      conteudo += `${venda.qtdEstoque} ${adicionaEspacos(
        venda.qtdEstoque.toString()
      )}`;
      conteudo += `${venda.qtdMinima} ${adicionaEspacos(
        venda.qtdMinima.toString()
      )}`;
      conteudo += `${venda.qtdVendida} ${adicionaEspacos(
        venda.qtdVendida.toString()
      )}`;
      conteudo += `${venda.qtdEstoqueAtual}  ${adicionaEspacos(
        venda.qtdEstoqueAtual.toString()
      )}`;
      conteudo += `${venda.qtdNecessaria} ${adicionaEspacos(
        venda.qtdNecessaria.toString()
      )}`;
      conteudo += `${venda.qtdTransf}\n`;
    });
    await criarArquivo("transfere.txt", conteudo);
  }
};

export const criarArquivoDivergencias = async (divergencias) => {
  await criarDiretorioResultado();

  if (divergencias.length > 0) {
    let conteudo = `=============================== \r\n`;

    divergencias.forEach((divergencia) => {
      conteudo += divergencia + "\r";
    });
    await criarArquivo("DIVERGENCIAS.txt", conteudo);
  }
};

export const criarArquivoTotcanais = async (vendasCanais) => {
  await criarDiretorioResultado();

  let conteudo = ` =============================== \r\n
  Quantidades de Vendas por canal\r\n
  1 - Representantes      ${vendasCanais.representantes}\r
  2 - Website             ${vendasCanais.website}\r
  3 - App móvel Android	  ${vendasCanais.appAndroid}\r
  4 - App móvel iPhone    ${vendasCanais.appIphone}\r
  `;

  await criarArquivo("TOTCANAIS.txt", conteudo);
};

const criarDiretorioResultado = async () => {
  try {
    if (!existsSync("./resultados")) {
      mkdirSync("./resultados");
    }
  } catch (err) {
    console.log("Aplicação deu um erro:\n", err);
  }
};

const criarArquivo = async (nomeArquivo, conteudo) => {
  appendFile(`./resultados/${nomeArquivo}`, conteudo, (err) => {
    if (err) {
      console.log(`Erro ao criar arquivo ${nomeArquivo}: `, err);
    }
  });
};

const adicionaEspacos = (string) => {
  let espacos = "";
  let espacosNecessarios = 9 - string.length;
  for (let i = 0; i < espacosNecessarios; i++) {
    espacos += " ";
  }

  return espacos;
};
