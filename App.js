// var readVendas = require("./Functions/readVendas.js");
import { produtosC1, produtosC2 } from "./Functions/Read/readProdutos.js";
import { vendasC1, vendasC2 } from "./Functions/Read/readVendas.js";
import Produto from "./Class/Produto.js";

import { montaProduto } from "./Functions/Tratamento/montaProduto.js";

// const prod = 
const teste = montaProduto(produtosC1());
console.log(teste)