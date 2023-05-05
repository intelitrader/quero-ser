import { Produtos } from "../models/produtos.model.js";

export const registrarProdutos = (listaProd) =>{

  let arrayProdutos = listaProd.split('\r\n');

  let produtos = [];

  arrayProdutos.forEach((produto) => {
    let dados = produto.split(';');
    try {
      if(dados[0] && dados[1] && dados[2])
        produtos.push(new Produtos(dados[0], parseInt(dados[1]), parseInt(dados[2])));

    } catch (err) {
      console.log(err);
    }
  });

  return produtos;
}