function __SearchCodeInProdutos(codigo, listaProdutos){
    var encontrou = false;
    for(i in listaProdutos){
        if(listaProdutos[i][0] == codigo){
            encontrou = true;
            posicao = i;
        }
    }
    return {encontrou, posicao};
}

function __CalcNecess(qtMin, qtAposVendas){
    if(qtAposVendas >= qtMin){
        return 0;
    }else{
        return qtMin - qtAposVendas
    }
}

function __CalcTransf(necess){
    if(necess > 1 && necess < 10){
        return 10;
    }else{
        return necess;
    }
}

function CreateFileContent (brute_data) {
    var produtos = brute_data.produtos;
    var vendas = brute_data.vendas;

    var obj = {
        "divergencias": [],
        "vendas": [],
        "canais": {
            "representantes": 0,
            "website": 0,
            "appAndroid": 0,
            "appIphone": 0
        }
    }


    for(var i=0; i < vendas.length; i++){
        var resultVendas = {
            "codigoProd": "",
            "qtCo": "",
            "qtMin": "",
            "qtVendas": "",
            "estqAposVendas": "",
            "necess": "",
            "transf": ""
        };
        var codigo_produto = vendas[i][0];
        var situacao_venda = vendas[i][2];
        var canal_venda = vendas[i][3];
        canal_venda == "1" ? obj.canais.representantes+=1 : canal_venda == "2" ? obj.canais.website+=1 : canal_venda == "3" ? obj.canais.appAndroid+=1 : canal_venda == "4" ? obj.canais.appIphone+=1: false;
        const prd = __SearchCodeInProdutos(codigo_produto, produtos);

        if(prd.encontrou == false || situacao_venda == "135" || situacao_venda == "190" || situacao_venda == "999"){ // Caso a situação da venda ou codigo do produto tenha algum problema
            var resultDivergencias = {
                "linha": (i+1).toString(),
                "codigo_produto": codigo_produto,
                "mensagem": situacao_venda == "135" ? "Venda cancelada" : situacao_venda == "190" ? "Venda não finalizada" : situacao_venda == "999" ? "Erro desconhecido. Acionar equipe de TI" : "Código de Produto não encontrado "+codigo_produto.toString()
            }
            obj.divergencias.push(resultDivergencias);
        }else{ // Caso a situação da venda e o código de produto estejam OK.
            
            resultVendas.codigoProd = codigo_produto;
            resultVendas.qtCo = produtos[prd.posicao][1];
            resultVendas.qtMin = produtos[prd.posicao][2];
            resultVendas.qtVendas = vendas[i][1];
            resultVendas.estqAposVendas = (parseInt(produtos[prd.posicao][1], 10) - parseInt(vendas[i][1], 10)).toString();
            resultVendas.necess = __CalcNecess(parseInt(resultVendas.qtMin), parseInt(resultVendas.estqAposVendas, 10));
            resultVendas.transf = __CalcTransf(resultVendas.necess);
            obj.vendas.push(resultVendas);
        }       
    }
    return obj;
}


module.exports = {
    CreateFileContent
}