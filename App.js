// var readVendas = require("./Functions/readVendas.js");
import montaProduto from "./Functions/Tratamento/montaProduto.js";
import Produto from "./Class/Produto.js";

const teste = montaProduto('./Entrada/c1_produtos.txt');

teste.forEach(element => console.log(element));
// console.log(teste)