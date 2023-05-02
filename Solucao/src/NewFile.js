const fs = require('fs');

function __ConstruirLinhaTransfere(codigoProd, qtCo, qtMin, qtVendas, estqAposVendas, necess, transf){
    qtCo.length == 3 ? qtCo = qtCo+="\t\t" : qtCo.length > 3 ? qtCo = qtCo+="\t" : 0;
    qtMin.length == 3 ? qtMin = qtMin+="\t\t" : qtMin.length > 3 ? qtMin = qtMin+="\t" : 0;
    qtVendas.length >= 1 ? qtVendas = qtVendas+="\t\t\t" : 0;
    estqAposVendas.length <= 3 ? estqAposVendas = estqAposVendas+="\t\t\t" : estqAposVendas.length > 3 ? estqAposVendas = estqAposVendas+="\t\t" : 0;
    necess.length <= 3 ? necess = necess+="\t\t" : necess.length > 3 ? necess = necess+="\t" : necess = necess+="\t\t";

    var str ="\n"+codigoProd+"\t"+qtCo+qtMin+qtVendas+estqAposVendas+necess+transf;
    return str;
}

function CreateTransfere(nomearquivo, conteudo){
    //setando cabeçalho.
    var cabeca = "Necessidade de Transferência Armazém para CO\n\nProduto	QtCO	QtMin	QtVendas	Estq.após	Necess.	Transf. de\n\t\t\t\t\t\t\t\t\tVendas\t\t\t\tArm p/ CO";
    var str = "";
    for(i in conteudo){
        str = str + __ConstruirLinhaTransfere(conteudo[i].codigoProd, conteudo[i].qtCo,conteudo[i].qtMin,conteudo[i].qtVendas,conteudo[i].estqAposVendas,conteudo[i].necess,conteudo[i].transf);        
    }    
    
    fs.writeFile(nomearquivo, cabeca+str, (err)=>{
        if(err){
            console.log(err);
        }else{
            return true;
        }
    });
    
}

function CreateTotCanais(nomearquivo, conteudo){
    const cabecalho = "Quantidades de Vendas por canal\n";
    const representantes = "\n1 - Representantes\t\t\t"+conteudo.representantes;
    const website = "\n2 - Website\t\t\t\t\t"+conteudo.website;
    const android = "\n3 - App móvel Android\t\t"+conteudo.appAndroid;
    const iphone = "\n4 - App móvel iPhone\t\t"+conteudo.appIphone;

    const cont = cabecalho+representantes+website+android+iphone;

    fs.writeFile(nomearquivo, cont, (err)=>{
        if(err){
            console.log(err);
        }else{
            return true;
        }
    });
}

function CreateDivergencias(nomearquivo, conteudo){
    var str = "";
    for(i in conteudo){
        var line = "Linha "+conteudo[i].linha+" - "+conteudo[i].mensagem+"\n";
        str = str+line;
    }
    
    fs.writeFile(nomearquivo, str, (err)=>{
        if(err){
            console.log(err);
        }else{
            return true;
        }
    });

}

module.exports = {
    CreateTransfere,
    CreateTotCanais,
    CreateDivergencias
}