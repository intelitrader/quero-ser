// var readVendas = require("./Functions/readVendas.js");
import { produtos } from "./Functions/Read/readTxt.js";
import Produto from "./Class/Produto.js";

import { montaProduto } from "./Functions/Tratamento/montaProduto.js";


const rawProdutos = produtos('./Entrada/c2_produtos.txt')
const teste = montaProduto(rawProdutos);
console.log(teste)