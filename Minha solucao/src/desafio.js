import { Produto } from '../model/produto.model.js'
import { Venda } from '../model/venda.model.js'
import fs from 'fs';
import { Transfere } from './relatorios/transfere.js';
import { Diverge } from './relatorios/diverge.js';
import { Canal } from './relatorios/totcanais.js';
import { FileHandler } from './utils/file-handler.js';

let data;
let produtos_array;
let estoque_produtos = []

let vendas_array;
let vendas_produtos= [];


data = FileHandler.readFile('../Casodeteste1/c1_produtos.txt')
produtos_array=data.split("\n");

data = FileHandler.readFile('../Casodeteste1/c1_vendas.txt')
vendas_array=data.split("\n");
  
for(let i=0; i<produtos_array.length; i++){
    const produto_string = produtos_array[i].split(";");
    const produto = new Produto(produto_string[0],parseInt(produto_string[1]),parseInt(produto_string[2]))
    estoque_produtos.push(produto);
}

for(let i=0; i<vendas_array.length; i++){
    const venda_string = vendas_array[i].split(";");
    const venda = new Venda(venda_string[0],parseInt(venda_string[1]),venda_string[2],venda_string[3])
    vendas_produtos.push(venda);
}

let transfere = new Transfere();
let diverge = new Diverge();
let canais_status = new Canal()

canais_status.canais(vendas_produtos);
transfere.transferencia(estoque_produtos,vendas_produtos)
diverge.divergencias(estoque_produtos,vendas_produtos)



