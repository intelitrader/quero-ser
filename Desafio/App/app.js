const fs = require('fs');

const {transferArray} = require('./transferProdGenerator');
const {totalCanal} = require('./totalcanalGenerator');
const {divergencias} = require('./divergenciasGenerator');

let totalcanaltxt = `Quantidades de Vendas por canal

1 - Representantes            ${totalCanal[0]}
2 - Website                   ${totalCanal[1]}
3 - App móvel Android         ${totalCanal[2]}
4 - App móvel iPhone          ${totalCanal[3]}
`;

let divergenciastxt = ``;

for(let i = 0; i < divergencias.length; i++){
  divergenciastxt += divergencias[i].message + '\r\n';
}

let transferenciastxt = `Necessidade de Transferência Armazém para CO

Produto QtCO   QtMin  QtVendas  Estq.após Vendas   Necessário   Transf. 
                                                                de Arm 
                                                                p/ CO
`

for(let i = 0; i < transferArray.length; i++){
  transferenciastxt += `${transferArray[i].codProd}   ${transferArray[i].qtCo}   ${transferArray[i].qtMin}      ${transferArray[i].qtVendida}        ${transferArray[i].estoqPosVenda}                ${transferArray[i].necessario}            ${transferArray[i].transfArmazemPCo} \r\n`
}

fs.writeFile('./txtFiles/transfere.txt', transferenciastxt, 'utf-8', (err) => {
  if(err){
    console.log(err);
  }else{
    console.log('data saved');
  }
})

fs.writeFile('./txtFiles/DIVERGENCIAS.txt', divergenciastxt, 'utf-8', (err) => {
  if(err){
    console.log(err);
  }else{
    console.log('data saved');
  }
})

fs.writeFile('./txtFiles/TOTCANAIS.txt', totalcanaltxt, 'utf-8', (err) => {
  if(err){
    console.log(err);
  }else{
    console.log('data saved');
  }
})













