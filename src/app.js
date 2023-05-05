import { lerArquivo, retornaTodosArquivos } from "./services/arquivos.service.js";
import { registrarProdutos } from "./services/produtos.service.js";
import { processarVendas, registrarVendas } from "./services/vendas.service.js";

export const executar = async () => {
  const filesDir = './src/files';

  let arquivosProds = await retornaTodosArquivos(`${filesDir}/produtos`);
  let arquivosVendas = await retornaTodosArquivos(`${filesDir}/vendas`);

  try {
    if(arquivosProds.length == 0) {
      console.log("Algum arquivo está faltando!");
      throw new Error('Coloque um arquivo de produto no diretório "src/files/produtos".');
    }
    if(arquivosVendas.length == 0) {
      console.log("Algum arquivo está faltando!");
      throw new Error('Coloque um arquivo de produto no diretório "src/files/vendas".');
    }

    let listaProds = await lerArquivo(`${filesDir}/produtos/${arquivosProds[0]}`);
    let listaVendas = await lerArquivo(`${filesDir}/vendas/${arquivosVendas[0]}`);
  
    const produtos = registrarProdutos(listaProds);
    const vendas = registrarVendas(listaVendas);
  
    processarVendas(produtos, vendas);
  }
  catch(err) {
    console.log(err);
  }
};
